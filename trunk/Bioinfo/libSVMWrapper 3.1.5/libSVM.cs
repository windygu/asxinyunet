/*
 * GNU LESSER GENERAL PUBLIC LICENSE
 * Version 3, 29 June 2007
 * 
 * Copyright 2011 Rafał "R@V" Prasał <rafal.prasal@gmail.com>
*/

using System;
using System.Text;
using System.Collections.Generic;


/// <summary>
/// Package for wrapper for libsvm.dll
/// </summary>
namespace libSVMWrapper
{
    /// <summary>
    /// Wrapper Class for libsvm.dll
    /// </summary>
    /// Usage examples:
    /// 
    ///     Loading model:
    /// @code
    ///             libSVM svm = new libSVM(); 
    ///             svm.Reload("model_file");       see Reload()
    /// @endcode
    /// 
    ///         or 
    ///         
    /// @code
    ///             libSVM svm = libSVM.Load("model_file");     see Load()
    /// @endcode
    /// 
    ///     Training model
    ///     
    ///         When you know parameters you want to use
    /// @code
    ///             libSVM_Problem Problem;                 see libSVM_Problem
    ///             libSVM_Parameter Parameter;             see libSVM_Parameter
    ///             libSVM svm = new libSVM(); 
    ///         
    ///             svm.Train(Problem, Parameter);
    /// @endcode
    /// 
    ///         or  When you have no idea what parameters to use
    ///         
    /// @code
    ///             libSVM_Problem Problem;                 see libSVM_Problem
    ///             libSVM_Parameter Parameter;             see libSVM_Parameter
    ///             libSVM svm = new libSVM(); 
    ///         
    ///             svm.TrainAuto(fold ,Problem, Parameter);      see TrainAuto()
    /// @endcode
    /// 
    ///         or  When you know search grids for parameters
    ///         
    /// @code
    ///             libSVM_Problem Problem;                 see libSVM_Problem
    ///             libSVM_Parameter Parameter;             see libSVM_Parameter
    ///             libSVM_Grid grid_c;                     see libSVM_Grid
    ///             ...
    /// 
    ///             libSVM svm = new libSVM(); 
    ///         
    ///             svm.TrainAuto(fold, Problem, Parameter, grid_c, ...);      //see TrainAuto()
    /// @endcode
    /// 
    ///     Saving model:
    /// 
    /// @code
    ///             libSVM svm;
    ///         
    ///             svm.Save("model_file");     see Save()
    /// @endcode
    /// 
    ///     Using model for prediction:
    ///     
    /// @code
    ///             double[] sample;
    ///             libSVM svm;
    ///         
    ///             double label = svm.Predict(x);          see Predict()
    /// @endcode
    /// 
    ///     Making libSVM Quiet (by default it is quiet)
    /// @code
    ///         LibSVM svm;
    ///         
    ///         svm.set_print_function(new PrintFunctionDelegate(svm.printf_quiet));        see printf_quiet()
    /// @endcode
    /// 
    /// Making libSVM not Quiet (by default it is quiet)
    /// @code
    ///         LibSVM svm;
    ///         
    ///         svm.set_print_function(new PrintFunctionDelegate(svm.printf_noquiet));      see printf_noquiet()
    /// @endcode
    /// 
    /// 
    ///     Removing model from memmory
    ///     
    /// @code
    ///             libSVM svm;
    ///             
    ///             svm.Dispose();             see dispose()
    /// @endcode
    /// 
    public partial class libSVM : IDisposable
    {
        /// <summary>
        /// Wrapper version
        /// </summary>
        public const string version = "3.1.5";

        /// <summary>
        /// internal pointers
        /// </summary>
        protected IntPtr _model_ptr = IntPtr.Zero;
        protected IntPtr _problem_ptr = IntPtr.Zero;
        protected IntPtr _parameter_ptr = IntPtr.Zero;

        private static PrintFunctionDelegate _printf;

        /// <summary>
        /// Construnctor disabling output to STDOUT
        /// </summary>
        public libSVM()
        {
            Set_printf(new PrintFunctionDelegate(libSVM.printf_quiet));
        }

        /// <summary>
        /// globally sets print function for libsvm.dll; Function should be static and class it comes from should exist all the time;
        /// </summary>
        /// <param name="printf"></param>
        public void Set_printf(PrintFunctionDelegate printf)
        {
            _printf = printf;

            svm_set_print_string_function(
                delegate_to_ptr(_printf)
                );
        }

        /// <summary>
        /// print nothing to STDOUT
        /// </summary>
        /// <param name="s">string to print</param>
        public static void printf_quiet(string s)
        {

        }

        /// <summary>
        /// print everithing to STDOUT
        /// </summary>
        /// <param name="s">string to print</param>
        public static void printf_noquiet(string s)
        {
            Console.Write(s);
        }

        /// <summary>
        /// Train model
        /// </summary>
        /// <param name="problem">samples and labels</param>
        /// <param name="parameter">model parameters</param>
        public void Train(libSVM_Problem problem, libSVM_Parameter parameter)
        {
            Dispose();

            _problem_ptr = libSVM_Problem_to_svm_problem_ptr(problem);
            _parameter_ptr = libSVM_Parameter_to_svm_parameter_ptr(parameter);

            IntPtr error_ptr = svm_check_parameter(_problem_ptr, _parameter_ptr);

            if (error_ptr != IntPtr.Zero)
                throw new Exception(ptr_to_string(error_ptr));

            _model_ptr = svm_train(_problem_ptr, _parameter_ptr);
        }

        /// <summary>
        /// Trains model automatically, using default Grids for parameter value search
        /// Similar to OpenCV
        /// </summary>
        /// <param name="fold">folds for samples >=2 </param>
        /// <param name="problem">samples and labels</param>
        /// <param name="parameter">model parameters</param>
        /// <returns>Accuracy in %</returns>
        public double TrainAuto(int fold, libSVM_Problem problem, libSVM_Parameter parameter)
        {
            return TrainAuto(fold, problem, parameter, libSVM_Grid.C(), libSVM_Grid.gamma(), libSVM_Grid.p(), libSVM_Grid.nu(), libSVM_Grid.coef0(), libSVM_Grid.degree());
        }

        /// <summary>
        /// Trains model automatically using users grids. if your svm_type/kernel_type does not need it then set it to null
        /// </summary>
        /// <param name="fold">folds for samples >=2 </param>
        /// <param name="problem">samples and labels</param>
        /// <param name="parameter">model parameters</param>
        /// <param name="grid_c">grid for C</param>
        /// <param name="grid_gamma">grid for gamma</param>
        /// <param name="grid_p">grid for p</param>
        /// <param name="grid_nu">grid for nu</param>
        /// <param name="grid_coef0">grid for coef</param>
        /// <param name="grid_degree">grid for degree</param>
        /// <returns>Accuracy in %</returns>
        public double TrainAuto(int fold, libSVM_Problem problem, libSVM_Parameter parameter, libSVM_Grid grid_c, libSVM_Grid grid_gamma, libSVM_Grid grid_p, libSVM_Grid grid_nu, libSVM_Grid grid_coef0, libSVM_Grid grid_degree)
        {
            Dispose();

            if (problem == null) throw new Exception("libSVMProblem not initialized");
            if (problem.samples == null) throw new Exception("libSVMProblem.samples = null");
            if (problem.labels == null) throw new Exception("libSVMProblem.labels = null");
            if (problem.samples.Length != problem.labels.Length) throw new Exception("libSVMProblem.samples.Length != libSVMProblem.labels.length");
            if (parameter == null) throw new Exception("libSVMParameter not initialized");
            if (parameter.weight == null && parameter.weight_label != null) throw new Exception("libSVMParameter.weight = null and libSVMParameter.weight_label != null");
            if (parameter.weight != null && parameter.weight_label == null) throw new Exception("libSVMParameter.weight_label = null and libSVMParameter.weight != null");
            if (parameter.weight != null && parameter.weight_label != null && parameter.weight_label.Length != parameter.weight.Length) throw new Exception("libSVMParameter.weight_label.Length != libSVMParameter.weight.Length");
            if (fold < 2 || fold > problem.samples.Length) throw new Exception("fold < 2 || fold > nr_samples");

            libSVM_Grid _grid_gamma = grid_gamma; 
            libSVM_Grid _grid_coef0 = grid_coef0;
            libSVM_Grid _grid_degree = grid_degree;            

            if (parameter.kernel_type == KERNEL_TYPE.LINEAR 
                || parameter.kernel_type == KERNEL_TYPE.PRECOMPUTED)
            {
                _grid_gamma = new libSVM_Grid();
                _grid_coef0 = new libSVM_Grid();
                _grid_degree = new libSVM_Grid();                
            }
            else if (parameter.kernel_type == KERNEL_TYPE.POLY)
            {
                if(_grid_gamma==null) throw new Exception("grid_gamma not set");
                if(_grid_coef0==null) throw new Exception("grid_coef0 not set");
                if(_grid_degree==null) throw new Exception("grid_degree not set");

            }
            else if (parameter.kernel_type == KERNEL_TYPE.RBF)
            {
                if(_grid_gamma==null) throw new Exception("grid_gamma not set");

                _grid_coef0 = new libSVM_Grid();
                _grid_degree = new libSVM_Grid();                
            }
            else if (parameter.kernel_type == KERNEL_TYPE.SIGMOID)
            {
                if(_grid_gamma==null) throw new Exception("grid_gamma not set");
                if(_grid_coef0==null) throw new Exception("grid_coef not set");
                _grid_degree = new libSVM_Grid();
            }
            else throw new Exception("unknown kernel_type");

            libSVM_Grid _grid_c = grid_c;
            libSVM_Grid _grid_p = grid_p;
            libSVM_Grid _grid_nu = grid_nu;             

            if (parameter.svm_type == SVM_TYPE.C_SVC 
                || parameter.svm_type == SVM_TYPE.ONE_CLASS)
            {
                if(_grid_c== null) throw new Exception("grid_C not set");

                _grid_nu = new libSVM_Grid();
                _grid_p = new libSVM_Grid();
            }
            else if (parameter.svm_type == SVM_TYPE.NU_SVC || parameter.svm_type == SVM_TYPE.NU_SVR)
            {
                if(_grid_nu== null) throw new Exception("grid_nu not set");

                _grid_c = new libSVM_Grid();
                _grid_p = new libSVM_Grid();                
            }
            else if (parameter.svm_type == SVM_TYPE.EPSILON_SVR)
            {
                if (_grid_p == null) throw new Exception("grid_p not set");

                _grid_c = new libSVM_Grid();
                _grid_nu = new libSVM_Grid();                               
            }
            else throw new Exception("unknown svm_type");

            double c=_grid_c.min;
            double p=_grid_p.min;
            double nu=_grid_nu.min;

            double gamma = _grid_gamma.min;
            double coef0 = _grid_coef0.min;
            double degree = _grid_degree.min;
            int f=0;

            int test_probe=0;
            int test_samples = 0;

            libSVM_Parameter train_parameter = new libSVM_Parameter();

            //copy parameters set by user;
            train_parameter.weight = parameter.weight;
            train_parameter.weight_label = parameter.weight_label;
            train_parameter.shrinking = parameter.shrinking;
            train_parameter.svm_type = parameter.svm_type;
            train_parameter.kernel_type = parameter.kernel_type;
            train_parameter.probability = parameter.probability;
            train_parameter.cache_size = parameter.cache_size;

            libSVM_Problem train_problem = new libSVM_Problem();
            libSVM_Problem test_problem = new libSVM_Problem();

            //fold
            do{
                train_problem.labels = new double[1];
                train_problem.samples = new SortedDictionary<int,double>[1];

                test_problem.labels = new double[1];
                test_problem.samples = new SortedDictionary<int,double>[1];

                int j = 0;
                int k = 0;
                for (int i = 0; i < problem.samples.Length; i++)
                    if ((i+1+f) % fold  == 0)
                    {                        
                        Array.Resize(ref test_problem.labels, j+1);
                        Array.Resize(ref test_problem.samples, j+1);

                        test_problem.labels[j] = problem.labels[i];
                        test_problem.samples[j] = problem.samples[i];
                        j++;                        
                    }
                    else
                    {
                        Array.Resize(ref train_problem.labels, k + 1);
                        Array.Resize(ref train_problem.samples, k + 1);

                        train_problem.labels[k] = problem.labels[i];
                        train_problem.samples[k] = problem.samples[i];
                        k++;
                    }

                //p
                p = _grid_p.min;
                do{
                    //nu
                    nu = _grid_nu.min;
                    do{
                        //gamma
                        gamma = _grid_gamma.min;
                        do{
                            //coef0
                            coef0 = _grid_coef0.min;
                            do{
                                //degree

                                degree = _grid_degree.min;
                                do{
                                    //c

                                    c = _grid_c.min;
                                    do{
                                        //svm_train alters problem_ptr so it's necessary to create it every time;
                                        IntPtr this_problem_ptr = libSVM_Problem_to_svm_problem_ptr(train_problem);
                                                                                    
                                        //set generated parameters
                                        train_parameter.C = c;
                                        train_parameter.p = p;
                                        train_parameter.nu = nu;
                                        train_parameter.gamma = gamma;
                                        train_parameter.degree = (int)degree;
                                        train_parameter.coef0 = coef0;

                                        IntPtr this_parameter_ptr = libSVM_Parameter_to_svm_parameter_ptr(train_parameter);

                                        IntPtr error_ptr = svm_check_parameter(this_problem_ptr, this_parameter_ptr);

                                        if (error_ptr != IntPtr.Zero)
                                            throw new Exception(ptr_to_string(error_ptr));
                                        
                                        IntPtr this_model_ptr = svm_train(this_problem_ptr,this_parameter_ptr);

                                        int this_test_probe=0;
                                        
                                        //count propperly recognized test_problem.samples
                                        for(int i=0; i<test_problem.labels.Length; i++)
                                        {
                                            IntPtr svm_nodes_ptr = sample_to_svm_nodes_ptr(test_problem.samples[i]);

                                            if(test_problem.labels[i]==svm_predict(this_model_ptr, svm_nodes_ptr))
                                                this_test_probe++;

                                            Free_ptr(ref svm_nodes_ptr);
                                        }

                                        //if first run then just copy this
                                        if(_model_ptr==IntPtr.Zero) 
                                        {
                                            _model_ptr = this_model_ptr;
                                            _parameter_ptr = this_parameter_ptr;
                                            _problem_ptr = this_problem_ptr;

                                            test_probe = this_test_probe;
                                            test_samples = test_problem.samples.Length;

                                            //exit when no better solution could be found
                                            if (test_probe == test_problem.samples.Length) goto leave;
                                        }
                                        else
                                            //if model was better than previous then free previous data and copy this
                                            if (this_test_probe > test_probe)
                                            {
                                                Free_svm_parameter_ptr(ref _parameter_ptr);
                                                Free_svm_problem_ptr(ref _problem_ptr);
                                                svm_free_and_destroy_model(ref _model_ptr);

                                                _parameter_ptr = this_parameter_ptr;                                                
                                                _problem_ptr = this_problem_ptr;
                                                _model_ptr = this_model_ptr;

                                                test_probe = this_test_probe;
                                                test_samples = test_problem.samples.Length;

                                                //exit when no better solution could be found;
                                                if (test_probe == test_problem.samples.Length) goto leave;
                                            }
                                            //if not then free this model
                                            else
                                                {
                                                    Free_svm_problem_ptr(ref this_problem_ptr);
                                                    Free_svm_parameter_ptr(ref this_parameter_ptr);
                                                    svm_free_and_destroy_model(ref this_model_ptr);
                                                }

                                        c *= _grid_c.step;
                                    }while(c<_grid_c.max);

                                    degree *= _grid_degree.step;
                                }while(degree<_grid_degree.max);

                                coef0 *= _grid_coef0.step;
                            }while(coef0<_grid_coef0.max);

                            gamma *= _grid_gamma.step;
                        }while(gamma<_grid_gamma.max);

                        nu*=_grid_nu.step;
                    }while(nu<_grid_nu.max);

                    p *= _grid_p.step;
                }while(p<_grid_p.max);

                f++;
            }while(f<fold);

        leave:
            return 100.0 * test_probe / (double)test_samples;
        }

        /// <summary>
        /// Save model to file
        /// </summary>
        /// <param name="filename">model file</param>
        public void Save(string filename)
        {
            if (_model_ptr == IntPtr.Zero) throw new Exception("model neither loaded nor trained");
            svm_save_model(filename, _model_ptr);
        }

        /// <summary>
        /// Reload libSVM model
        /// </summary>
        /// <param name="filename">name of model file</param>
        public void Reload(string filename)
        {
            Dispose();

            _model_ptr = svm_load_model(filename);

            if (_model_ptr == IntPtr.Zero) throw new Exception("bad model file");
        }



        /// <summary>
        ///  Load model from file
        /// </summary>
        /// <param name="filename">Model file</param>                
        /// <returns>libSVM</returns>
        public static libSVM Load(string filename)
        {            
            libSVM svm = new libSVM();

            svm.Reload(filename);

            return svm;
        }

        /// <summary>
        /// Predict Label for sample
        /// </summary>
        /// <param name="sample">sample</param>
        /// <returns>label</returns>
        public double Predict(SortedDictionary<int,double> sample)
        {
            if (_model_ptr == IntPtr.Zero) throw new Exception("model neither loaded nor trained");

            IntPtr svm_nodes_ptr = sample_to_svm_nodes_ptr(sample);

            double ret = svm_predict(_model_ptr, svm_nodes_ptr);

            Free_ptr(ref svm_nodes_ptr);

            return ret;
        }

        /// <summary>
        /// GetAccuracy for problem
        /// </summary>
        /// <param name="problem">problem</param>
        /// <returns>accuracy in %</returns>
        public double GetAccuracy(libSVM_Problem problem)
        {
            if(problem.samples == null || problem.samples.Length==0) throw new Exception("GetAccuracy no samples");
            if(problem.labels == null || problem.labels.Length==0) throw new Exception("GetAccuracy no labels");

            if(problem.samples.Length!=problem.labels.Length) throw new Exception("GetAccuracy labels.length!=samples.length");

            int correctPredictions = 0;
            for (int i = 0; i < problem.samples.Length; i++)
                if (problem.samples[i] != null
                    && problem.samples[i].Count > 0
                    && Predict(problem.samples[i]) == problem.labels[i])
                        correctPredictions++;
                
            return correctPredictions / (double)problem.samples.Length * 100.0;            
        }

        /// <summary>
        /// Free memmory
        /// </summary>
        public void Dispose()
        {
            if (_problem_ptr != IntPtr.Zero) Free_svm_problem_ptr(ref _problem_ptr);
            if (_parameter_ptr != IntPtr.Zero) Free_svm_parameter_ptr(ref _parameter_ptr);
            if (_model_ptr != IntPtr.Zero) svm_free_and_destroy_model(ref _model_ptr);
        }
    }
}


public delegate void PrintFunctionDelegate(string str);