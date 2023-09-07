using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmPromotion
{

    public interface IHelper
    {

        string Add<T>();
        string Delete<T>();
        string Update<T>();
        string Query<T>();
    }
    public class SqlHelper : IHelper
    {
        public string Add<T>()
        {
            return "这是SQLHelper里的Add方法";
        }

        public string Delete<T>()
        {
            return "这是SQLHelper里的Delete方法";
        }

        public string Query<T>()
        {
            return "这是SQLHelper里的Query方法";
        }

        public string Update<T>()
        {
            return "这是SQLHelper里的Update方法";
        }
    }


    //需要扩展新的功能，但是仍然需要用之前的接口
    public class RedisHelper
    {
        public string AddRedis<T>()
        {
            return "这是RedisHelper里的Add方法";
        }

        public string DeleteRedis<T>()
        {
            return "这是RedisHelper里的Delete方法";
        }

        public string QueryRedis<T>()
        {
            return "这是RedisHelper里的Query方法";
        }

        public string UpdateRedis<T>()
        {
            return "这是RedisHelper里的Update方法";
        }
    }



    //【方法1】类适配器（继承）

    public class RedisHelperInherit : RedisHelper, IHelper
    {
      
        public string Add<T>()
        {
            return base.AddRedis<T>();
        }

        public string Delete<T>()
        {
            return base.DeleteRedis<T>();
        }

        public string Query<T>()
        {
            return base.QueryRedis<T>();
        }

        public string Update<T>()
        {
            return base.UpdateRedis<T>();
        }
    }


    //【方法2】对象适配器  ---产生了一个新类

    public class RedisHelperIObject : IHelper
    {
        //3种注入方式
        //【1】私有字段或者私有属性
        private RedisHelper redisHelper = new RedisHelper();

        //[2]构造函数注入（可以传入不同实例）
        //private RedisHelper redisHelper = null;
        //public RedisHelperIObject(RedisHelper obj )
        //{
        //    this.redisHelper = obj;
        //}

        //[3]方法注入
        //private RedisHelper redisHelper = null;
        //public void Inject(RedisHelper obj)
        //{
        //    this.redisHelper = obj;
        //}


        public string Add<T>()
        {
            return redisHelper.AddRedis<T>();
        }

        public string Delete<T>()
        {
            return redisHelper.DeleteRedis<T>();
        }

        public string Query<T>()
        {
            return redisHelper.QueryRedis<T>();
        }

        public string Update<T>()
        {
            return redisHelper.UpdateRedis<T>();
        }
    }

}
