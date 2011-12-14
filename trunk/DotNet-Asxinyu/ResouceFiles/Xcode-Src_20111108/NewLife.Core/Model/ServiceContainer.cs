using System;

namespace NewLife.Model
{
    /// <summary>�����������ࡣʹ�÷��ͻ��࣬������Ϊ����������ľ�̬���캯����</summary>
    /// <typeparam name="TService">�������������</typeparam>
    /// <remarks>
    /// ����������ͨ���̳е�ǰ��ʵ��һ��˽�еķ���λ��������Ϊ������ṩ����λ����
    /// ����ڲ���Ĭ��ʵ�ֿ����ھ�̬���캯���н����޸���ע�ᡣ
    /// ��ΪԼ��������ڲ��ķ���λȫ��ͨ��������ɣ���֤������ʹ��ǰ�������ע�ᡣ
    /// </remarks>
    public class ServiceContainer<TService> where TService : ServiceContainer<TService>, new()
    {
        #region ��̬���캯��
        static ServiceContainer()
        {
            // ʵ����һ������Ϊ�˴�������ľ�̬���캯��
            TService service = new TService();
        }
        #endregion

        #region ��ǰ��̬��������
        /// <summary>��ǰ��������</summary>
        public static IObjectContainer Container { get { return ObjectContainer.Current; } }
        #endregion

        #region ����
        /// <summary>
        /// ע�����ͺ�����
        /// </summary>
        /// <typeparam name="TInterface">�ӿ�����</typeparam>
        /// <typeparam name="TImplement">ʵ������</typeparam>
        /// <param name="name">����</param>
        /// <param name="priority">���ȼ�</param>
        /// <returns></returns>
        public static IObjectContainer Register<TInterface, TImplement>(String name = null, Int32 priority = 0)
        {
            return Container.Register<TInterface, TImplement>(name, priority);
        }

        /// <summary>
        /// ע��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="impl"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IObjectContainer Register<T>(Type impl, String name = null)
        {
            return Container.Register(typeof(T), impl, name);
        }

        /// <summary>
        /// ��������ָ�����Ƶ�ʵ��
        /// </summary>
        /// <typeparam name="TInterface">�ӿ�����</typeparam>
        /// <param name="name">����</param>
        /// <param name="extend">��չ����Ϊture��nameΪnull���Ҳ���ʱ�����õ�һ��ע���name��Ϊnull���Ҳ���ʱ������nullע����</param>
        /// <returns></returns>
        public static TInterface Resolve<TInterface>(String name = null, Boolean extend = false)
        {
            return Container.Resolve<TInterface>(name, extend);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <typeparam name="TInterface">�ӿ�����</typeparam>
        /// <param name="name">����</param>
        /// <param name="extend">��չ����Ϊture��nameΪnull���Ҳ���ʱ�����õ�һ��ע���name��Ϊnull���Ҳ���ʱ������nullע����</param>
        /// <returns></returns>
        public static Type ResolveType<TInterface>(String name = null, Boolean extend = false)
        {
            return Container.ResolveType(typeof(TInterface), name, extend);
        }
        #endregion
    }
}