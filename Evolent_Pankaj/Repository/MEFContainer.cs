
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Evolent_Pankaj.Repository
{
    public static class MEFContainer

    {

        private static CompositionContainer compositionContainer = null;

        public static CompositionContainer Container

        {

            get

            {

                if (compositionContainer == null)

                {

                    var directoryCatalog =

                         new DirectoryCatalog(

                        Path.GetDirectoryName(

                        Assembly.GetExecutingAssembly().Location));

                    compositionContainer = new CompositionContainer(directoryCatalog);

                }

                return compositionContainer;

            }

        }

    }
}