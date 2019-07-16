using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using GyCodeTemplate.Repository.Interface;
using GyCodeTemplate.Repository;
using GyCodeTemplate.Service;
using GyCodeTemplate.Service.Interface;

namespace GyCodeTemplate.Common
{
    public static class Container
    {
        public static IContainer Instance;

        /// <summary>
        /// 初始化容器
        /// </summary>
        /// <returns></returns>
        public static void Init()
        {
            //新建容器构建器，用于注册组件和服务
            var builder = new ContainerBuilder();
            //自定义注册
            MyBuild(builder);
            //利用构建器创建容器
            Instance = builder.Build();
        }

        /// <summary>
        /// 自定义注册
        /// </summary>
        /// <param name="builder"></param>
        public static void MyBuild(ContainerBuilder builder)
        {
            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>();
        }
    }
}
