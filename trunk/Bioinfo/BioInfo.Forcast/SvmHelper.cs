using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libSVMWrapper;

namespace BioInfo.Forcast
{
    /// <summary>
    /// Svm测试帮助类
    /// 1.采用libSVMWrapper最新版
    /// 2.封装本项目常用的功能方法
    /// </summary>
    public class SvmHelper
    {
        #region 数据读取与保存
        #endregion

        #region
        public static void Test(string trainFileName,string testFileName)
        {
            libSVM svm = new libSVM();
            //读取训练集
            libSVM_Problem Problem = libSVM_Problem.Load(trainFileName );
            //配置参数
            libSVM_Parameter Parameter = new libSVM_Parameter();
            Parameter.kernel_type = KERNEL_TYPE.RBF ;//3 SIGMOID
            Parameter.gamma = 0.01;
            Parameter.C = 8;
            Parameter.probability = true ;
            //训练模型,可以动态保存，下次直接使用
            svm.Train(Problem, Parameter);            
            libSVM_Problem test = libSVM_Problem.Load(testFileName);            
            //double result = svm.Predict(test.samples[0]);           
            var result = test.samples.Select(n => svm.Predict(n)).ToList();
        }
        #endregion

        #region
        #endregion

        #region
        #endregion
    }
}
