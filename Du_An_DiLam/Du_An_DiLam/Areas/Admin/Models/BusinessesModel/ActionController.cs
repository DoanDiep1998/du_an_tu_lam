using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Du_An_DiLam.Areas.Admin.Models.BusinessesModel
{
    public class ActionController
    {
        // lấy controler theo namespace
        public List<Type> GetController(string namespaces)
        {
            List<Type> list = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces)).OrderBy(x => x.Name);
            return types.ToList();

        }
        // lấy action theo controller
        public List<string> GetActions(Type controller)
        {

            List<string> listAction = new List<string>();
            IEnumerable<MemberInfo> memberInfos = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).OrderBy(x => x.Name);
            foreach(MemberInfo method in memberInfos)
            {

                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listAction.Add(method.Name.ToString());
                }
            }
            return listAction;
        }
    }
}