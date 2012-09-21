/*
 * GNU LESSER GENERAL PUBLIC LICENSE
 * Version 3, 29 June 2007
 * 
 * Copyright 2011 Rafał "R@V" Prasał <rafal.prasal@gmail.com>
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/// <summary>
/// Package for wrapper for libsvm.dll
/// </summary>
namespace libSVMWrapper
{

    public partial class libSVM
    {
        #region Memmory_Management

        protected IntPtr Alloc_ptr(int _size)
        {
            return Marshal.AllocHGlobal(_size);
        }

        protected void Free_ptr(ref IntPtr _ptr)
        {
            Marshal.FreeHGlobal(_ptr);

            _ptr = IntPtr.Zero;
        }

        #endregion

        #region LibSVM_structure_convertions

        protected string ptr_to_string(IntPtr _ptr)
        {
            return Marshal.PtrToStringAnsi(_ptr);
        }

        
        /// <summary>
        /// fuctions gets intptr for delegate
        /// </summary>
        /// <param name="_delegate">delegate to convert</param>
        /// <returns>IntPtr</returns>
        protected IntPtr delegate_to_ptr(Delegate _delegate)
        {
            return Marshal.GetFunctionPointerForDelegate(_delegate);
        }

        /// <summary>
        /// Creates svm_node[] from double[]. To dispose svm_node[] use Destroy_svm_nodes.
        /// </summary>
        /// <param name="sample">Sample</param>
        /// <returns>unmanaged IntPtr to svm_node[]</returns>
        protected IntPtr sample_to_svm_nodes_ptr(SortedDictionary<int,double> sample)
        {
            if (sample == null || sample.Count==0) return IntPtr.Zero;
        
            IntPtr sample_node_ptr = Alloc_ptr(Marshal.SizeOf(typeof(svm_node)) * (sample.Count + 1));
                
            IntPtr ptr = sample_node_ptr;
            int iptr = sample_node_ptr.ToInt32();

            svm_node node;
            
            foreach (KeyValuePair<int, double> s in sample)
            {            
                node = new svm_node();
              
                node.index = s.Key;
                node.value = s.Value;

                Marshal.StructureToPtr(node, ptr, false);
                iptr += Marshal.SizeOf(typeof(svm_node));
                ptr = new IntPtr(iptr);
            }            

            node = new svm_node();
            node.index = -1;
            node.value = 0.0;
            Marshal.StructureToPtr(node, ptr, false);

            return sample_node_ptr;
        }


        protected void ptr_to_array(int len, ref int[] array, IntPtr array_ptr)
        {
            array = new int[len];

            IntPtr ptr = array_ptr;
            int iptr = ptr.ToInt32();

            for (int i = 0; i < len; i++)
            {
                ptr = new IntPtr(iptr + i * Marshal.SizeOf(typeof(int)));

                array[i] = Marshal.ReadInt32(ptr);
            }
        }

        protected void ptr_to_array(int len, ref double[] array, IntPtr array_ptr)
        {
            array = new double[len];

            IntPtr ptr = array_ptr;
            int iptr = ptr.ToInt32();

            for (int i = 0; i < len; i++)
            {
                ptr = new IntPtr(iptr + i * Marshal.SizeOf(typeof(double)));
                array[i] = (double) Marshal.PtrToStructure(ptr, typeof(double)); 
            }
        }

        protected IntPtr array_to_ptr(double[] array)
        {
            if (array == null) return IntPtr.Zero;

            IntPtr ptr = Alloc_ptr(Marshal.SizeOf(typeof(double)) * array.Length);

            IntPtr xptr = ptr;
            int ixptr = ptr.ToInt32();

            for (int i = 0; i < array.Length; i++)
            {
                Marshal.StructureToPtr(array[i], xptr, false);

                ixptr += Marshal.SizeOf(typeof(double));
                xptr = new IntPtr(ixptr);
            }

            return ptr;
        }

        protected IntPtr array_to_ptr(int[] array)
        {
            if (array == null) return IntPtr.Zero;
            IntPtr ptr = Alloc_ptr(Marshal.SizeOf(typeof(int)) * array.Length);

            IntPtr xptr = ptr;
            int ixptr = ptr.ToInt32();

            for (int i = 0; i < array.Length; i++)
            {
                Marshal.StructureToPtr(array[i], xptr, false);

                ixptr += Marshal.SizeOf(typeof(int));
                xptr = new IntPtr(ixptr);
            }

            return ptr;
        }

        private libSVM_Model model_ptr_to_LibSVM_Model(IntPtr model_ptr)
        {
            svm_model model = (svm_model)Marshal.PtrToStructure(model_ptr, typeof(svm_model));

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="problemx"></param>
        /// <returns></returns>
        protected IntPtr libSVM_Problem_to_svm_problem_ptr(libSVM_Problem problem)
        {
            if (problem == null) throw new Exception("libSVMProblem not initialized");

            if (problem.samples == null) throw new Exception("libSVMProblem.samples = null");
            if (problem.labels == null) throw new Exception("libSVMProblem.labels = null");
            if (problem.samples.Length != problem.labels.Length) throw new Exception("libSVMProblem.samples.Length != libSVMProblem.labels.length");

            IntPtr problem_ptr = IntPtr.Zero;
            svm_problem _problem = new svm_problem();

            _problem.l = problem.samples.Length;
            _problem.y = array_to_ptr(problem.labels);
            _problem.x = Alloc_ptr(Marshal.SizeOf(typeof(IntPtr)) * _problem.l);

            IntPtr xptr = _problem.x;
            int ixptr = xptr.ToInt32();

            for (int i = 0; i < _problem.l; i++)
            {
                IntPtr svm_nodes = sample_to_svm_nodes_ptr(problem.samples[i]);

                xptr = new IntPtr(ixptr);
                Marshal.StructureToPtr(svm_nodes, xptr, false);

                ixptr += Marshal.SizeOf(typeof(IntPtr));
            }

            problem_ptr = Alloc_ptr(Marshal.SizeOf(typeof(svm_problem)));
            Marshal.StructureToPtr(_problem, problem_ptr, false);

            return problem_ptr;
        }

        /// <summary>
        /// clears memory for prob_ptr
        /// </summary>
        /// <param name="problem_ptr"></param>
        protected void Free_svm_problem_ptr(ref IntPtr problem_ptr)
        {
            svm_problem problem = (svm_problem)Marshal.PtrToStructure(problem_ptr, typeof(svm_problem));

            Free_ptr(ref problem.y);

            IntPtr ptr = problem.x;
            int iptr = ptr.ToInt32();

            for (int i = 0; i < problem.l; i++)
            {
                ptr = new IntPtr(iptr + i * Marshal.SizeOf(typeof(IntPtr)));

                IntPtr node_ptr = Marshal.ReadIntPtr(ptr);

                Free_ptr(ref node_ptr);
            }

            Free_ptr(ref problem.x);
            Free_ptr(ref problem_ptr);

            problem_ptr = IntPtr.Zero;
        }

        protected IntPtr libSVM_Parameter_to_svm_parameter_ptr(libSVM_Parameter parameter)
        {
            if (parameter == null) throw new Exception("libSVM_Parameter not initialized");

            if (parameter.weight == null && parameter.weight_label != null) throw new Exception("libSVMParameter.weight = null and libSVMParameter.weight_label != null");
            if (parameter.weight != null && parameter.weight_label == null) throw new Exception("libSVMParameter.weight_label = null and libSVMParameter.weight != null");
            if (parameter.weight != null && parameter.weight_label != null && parameter.weight_label.Length != parameter.weight.Length) throw new Exception("libSVMParameter.weight_label.Length != libSVMParameter.weight.Length");

            svm_parameter _parameter = new svm_parameter();

            _parameter.C = parameter.C;
            _parameter.cache_size = parameter.cache_size;
            _parameter.coef0 = parameter.coef0;
            _parameter.degree = parameter.degree;
            _parameter.eps = parameter.eps;
            _parameter.gamma = parameter.gamma;
            _parameter.kernel_type = (int)parameter.kernel_type;

            if (parameter.weight == null && parameter.weight_label == null)
            {                
                _parameter.nr_weight = 0;
                _parameter.weight = IntPtr.Zero;
                _parameter.weight_label = IntPtr.Zero;
            }
            else
                {
                    _parameter.nr_weight = parameter.weight_label.Length;

                    _parameter.weight = array_to_ptr(parameter.weight);
                    _parameter.weight_label = array_to_ptr(parameter.weight_label);                    
                }

            _parameter.nu = parameter.nu;
            _parameter.p = parameter.p;
            _parameter.probability = (parameter.probability == true ? 1 : 0); 
            _parameter.shrinking = (parameter.shrinking==true?1:0);
            _parameter.svm_type = (int)parameter.svm_type;

            IntPtr parameter_ptr = Alloc_ptr(Marshal.SizeOf(typeof(svm_parameter)));
            Marshal.StructureToPtr(_parameter, parameter_ptr, false);

            return parameter_ptr;
        }

        /// <summary>
        /// clears memmory for param_ptr
        /// </summary>
        /// <param name="sample_node_ptr"></param>
        protected void Free_svm_parameter_ptr(ref IntPtr parameter_ptr)
        {
            svm_parameter parameter = (svm_parameter)Marshal.PtrToStructure(parameter_ptr, typeof(svm_parameter));

            Free_ptr(ref parameter.weight);
            Free_ptr(ref parameter.weight_label);

            Free_ptr(ref parameter_ptr);           
        }

        #endregion

        #region libSVM_PInvoke

        // struct svm_model *svm_train(const struct svm_problem *prob, const struct svm_parameter *param);

        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr svm_train(IntPtr prob, IntPtr param);

        //void svm_cross_validation(const struct svm_problem *prob, const struct svm_parameter *param, int nr_fold, double *target);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_cross_validation(IntPtr prob, IntPtr param, int nr_fold, IntPtr target);

        //int svm_save_model(const char *model_file_name, const struct svm_model *model);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        protected static extern int svm_save_model(String model_file_name, IntPtr model);

        //struct svm_model *svm_load_model(const char *model_file_name);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr svm_load_model(string model_file_name);

        //int svm_get_svm_type(const struct svm_model *model);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int svm_get_svm_type(IntPtr model);

        //int svm_get_nr_class(const struct svm_model *model);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int svm_get_nr_class(IntPtr model);

        //void svm_get_labels(const struct svm_model *model, int *label);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_get_labels(IntPtr model, IntPtr label);

        //double svm_get_svr_probability(const struct svm_model *model);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern double svm_get_svr_probability(IntPtr model);

        //double svm_predict_values(const struct svm_model *model, const struct svm_node *x, double* dec_values);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern double svm_predict_values(IntPtr model, IntPtr x, IntPtr dec_values);

        //double svm_predict(const struct svm_model *model, const struct svm_node *x);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern double svm_predict(IntPtr model, IntPtr x);

        //double svm_predict_probability(const struct svm_model *model, const struct svm_node *x, double* prob_estimates);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern double svm_predict_probability(IntPtr model, IntPtr x, IntPtr prob_estimates);

        //void svm_free_model_content(struct svm_model *model_ptr);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_free_model_content(IntPtr model_ptr);

        //void svm_free_and_destroy_model(struct svm_model **model_ptr_ptr);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_free_and_destroy_model(ref IntPtr model_ptr_ptr);

        //void svm_destroy_param(struct svm_parameter *param);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_destroy_param(IntPtr param);

        //const char *svm_check_parameter(const struct svm_problem *prob, const struct svm_parameter *param);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr svm_check_parameter(IntPtr prob, IntPtr param);

        // int svm_check_probability_model(const struct svm_model *model);
        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern int svm_check_probability_model(IntPtr model);

        [DllImport("libsvm.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void svm_set_print_string_function(IntPtr print_function);


        #endregion
    }

    #region libSVM_internal_structures
    /// <summary>
    /// INTERNAL struct svm_node
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class svm_node
    {
        /// <summary>
        /// int index;
        /// </summary>
        public int index;

        /// <summary>
        /// double value;
        /// </summary>
        public double value;
    }


    /// <summary>
    /// INTERNAL struct svm_problem
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class svm_problem
    {
        /// <summary>
        /// int l;
        /// </summary>
        public int l;

        /// <summary>
        /// double *y;
        /// </summary>
        public IntPtr y;

        /// <summary>            
        /// struct svm_node** x;
        /// </summary>
        public IntPtr x;
    }


    /// <summary>
    /// INTERNAL struct svm_parameter
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class svm_parameter
    {
        /// <summary>
        /// int svm_type;
        /// </summary>
        public int svm_type;

        /// <summary>
        /// int kernel_type;
        /// </summary>
        public int kernel_type;

        /// <summary>
        /// int degree;	            for poly 
        /// </summary>
        public int degree;

        /// <summary>
        /// double gamma;           for poly/rbf/sigmoid
        /// </summary>
        public double gamma;

        /// <summary>
        /// double coef0;           for poly/sigmoid
        /// </summary>
        public double coef0;

        /* these are for training only */

        /// <summary>
        /// double cache_size;      in MB
        /// </summary>
        public double cache_size;

        //
        /// <summary>
        /// double eps;             stopping criteria
        /// </summary>
        public double eps;

        /// <summary>
        /// double C;               for C_SVC, EPSILON_SVR and NU_SVR
        /// </summary>
        public double C;

        /// <summary>
        /// int weight;             for C_SVC
        /// </summary>
        public int nr_weight;

        /// <summary>
        /// int *weight_label;      for C_SVC 
        /// </summary>
        public IntPtr weight_label;

        /// <summary>
        /// double* weight;         for C_SVC
        /// </summary>
        public IntPtr weight;

        /// <summary>
        /// double nu;              for NU_SVC, ONE_CLASS, and NU_SVR
        /// </summary>
        public double nu;

        /// <summary>
        /// double p;               for EPSILON_SVR
        /// </summary>
        public double p;

        /// <summary>
        /// int shrinking;          use the shrinking heuristics
        /// </summary>
        public int shrinking = 0;

        /// <summary>
        /// int probability;        do probability estimates
        /// </summary>
        public int probability = 0;
    }

    /// <summary>
    /// INTERNAL struct svm_model
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class svm_model
    {
        /// <summary>
        /// struct svm_parameter param;	    parameter 
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        public svm_parameter param;

        /// <summary>
        /// int nr_class;                   number of classes, = 2 in regression/one class svm
        /// </summary>
        public int nr_class;

        //
        /// <summary>
        /// int l;                          total #SV
        /// </summary>
        public int l;

        /// <summary>
        /// struct svm_node **SV;           SVs (SV[l])
        /// </summary>
        public IntPtr SV;

        /// <summary>
        /// double** sv_coef;               coefficients for SVs in decision functions (sv_coef[k-1][l])
        /// </summary>    
        public IntPtr sv_coef;

        /// <summary>
        /// double* rho;                    constants in decision functions (rho[k*(k-1)/2])
        /// </summary>        
        public IntPtr rho;

        /// <summary>
        /// double* probA;                  
        /// </summary>    
        public IntPtr probA;

        //
        /// <summary>
        /// double* probB;                  pariwise probability information
        /// </summary>
        public IntPtr probB;

        /* for classification only */
        //
        /// <summary>
        /// int* label;                     label of each class (label[k])
        /// </summary>
        public IntPtr label;

        /// <summary>
        /// double** nSV;                   number of SVs for each class (nSV[k]), nSV[0] + nSV[1] + ... + nSV[k-1] = l 
        /// </summary>
        public IntPtr nSV;

        /// <summary>
        /// int free_sv;                    1 if svm_model is created by svm_load_model and 0 if trained
        /// </summary>
        public int free_sv;
    };

    #endregion
}
