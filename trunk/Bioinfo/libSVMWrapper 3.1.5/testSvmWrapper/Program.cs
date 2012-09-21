using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSVMWrapper;
namespace testSvmWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            libSVM_Problem Problem = libSVM_Problem.Load("../../data/train.dat");
            libSVM_Parameter Parameter = new libSVM_Parameter(); 
            libSVM svm = new libSVM();

            Parameter.svm_type = SVM_TYPE.C_SVC;
            Parameter.kernel_type = KERNEL_TYPE.LINEAR;

            svm = new libSVM();
            svm.Train(Problem, Parameter);
            libSVM_Problem Test = libSVM_Problem.Load("../../data/test.dat");
            svm.Predict(Test.samples [0]);
            Console.ReadLine();
            svm.Dispose();

            svm = new libSVM();
            Console.WriteLine("loaded");
            Problem.Save("../../data/train_saved");   Console.WriteLine("saved"); 
            //svm.TrainAuto(10, Problem, Parameter, libSVM_Grid.C(), libSVM_Grid.gamma(), libSVM_Grid.p(), libSVM_Grid.nu(), libSVM_Grid.coef0(), libSVM_Grid.degree());
            libSVM_Grid grid = new libSVM_Grid();
            svm.TrainAuto(10, Problem, Parameter, grid, null, null, null, null, null);     Console.WriteLine("trained");
            svm.Save("../../data/model_file");  Console.WriteLine("model saved");
            Console.WriteLine("10cfv training complete");
            svm.Dispose();     
            Console.ReadLine(); 
        } 
    }
}  
/*
Wrapper Class for libsvm.dll.

Usage examples:

Loading model:

             libSVM svm = new libSVM(); 
             svm.Reload("model_file");       see Reload()
or

             libSVM svm = libSVM.Load("model_file");     see Load()
Training model

When you know parameters you want to use

             libSVM_Problem Problem;                 see libSVM_Problem
             libSVM_Parameter Parameter;             see libSVM_Parameter
             libSVM svm = new libSVM(); 
         
             svm.Train(Problem, Parameter);
or When you have no idea what parameters to use

             libSVM_Problem Problem;                 see libSVM_Problem
             libSVM_Parameter Parameter;             see libSVM_Parameter
             libSVM svm = new libSVM(); 
         
             svm.TrainAuto(fold ,Problem, Parameter);      see TrainAuto()
or When you know search grids for parameters

             libSVM_Problem Problem;                 see libSVM_Problem
             libSVM_Parameter Parameter;             see libSVM_Parameter
             libSVM_Grid grid_c;                     see libSVM_Grid
             ...
 
             libSVM svm = new libSVM(); 
         
             svm.TrainAuto(fold, Problem, Parameter, grid_c, ...);      //see TrainAuto()
Saving model:

             libSVM svm;
         
             svm.Save("model_file");     see Save()
Using model for prediction:

             double[] sample;
             libSVM svm;
         
             double label = svm.Predict(x);          see Predict()
Making libSVM Quiet (by default it is quiet)

         LibSVM svm;
         
         svm.set_print_function(new PrintFunctionDelegate(svm.printf_quiet));        see printf_quiet()
Making libSVM not Quiet (by default it is quiet)

         LibSVM svm;
         
         svm.set_print_function(new PrintFunctionDelegate(svm.printf_noquiet));      see printf_noquiet()
Removing model from memmory

             libSVM svm;
             
             svm.Dispose();             see dispose()
*/