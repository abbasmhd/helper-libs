using System;
using JetBrains.Annotations;

namespace Helpers.Reshaper {

    public static class Annotations {

        //[SourceTemplate]
        //public static void ForEach<T>(this IEnumerable<T> x)
        //{
        //    foreach (var i in x) {
        //        //$ $END$
        //    }
        //}

        //[SourceTemplate]
        //public static void Bar<T>(this T entity)
        //{
        //    /*$ var $entity$Id = entity.GetId();
        //    DoSomething($entity$Id); */
        //}

        /// <summary>
        ///     User with resharper auto complete only
        /// </summary>
        /// <param name="entity"></param>
        [SourceTemplate]
        public static void IfNotNullOrWhiteSpace(this string entity) {
            if(!String.IsNullOrWhiteSpace(entity)) {
                //$ $END$
            }
        }

        /// <summary>
        ///     User with resharper auto complete only
        /// </summary>
        /// <param name="entity"></param>
        [SourceTemplate]
        public static void IfNullOrWhiteSpace(this string entity) {
            if(String.IsNullOrWhiteSpace(entity)) {
                //$ $END$
            }
        }

        /// <summary>
        ///     User with resharper auto complete only
        /// </summary>
        /// <param name="entity"></param>
        [SourceTemplate]
        public static void IfNull<T>(this T entity) {
            if(entity == null) {
                //$ $END$
            }
        }

        [SourceTemplate]
        public static void IfNotNull<T>(this T entity) {
            if(entity != null) {
                //$ $END$
            }
        }

    }

}
