﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libreria.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MensajesAlertasResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MensajesAlertasResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Libreria.Resource.MensajesAlertasResources", typeof(MensajesAlertasResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se Cargo ningun Archivo.
        /// </summary>
        public static string ArchivoNoCargado {
            get {
                return ResourceManager.GetString("ArchivoNoCargado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El Archivo no se cargo o no existe.
        /// </summary>
        public static string ArchivoNoExiste {
            get {
                return ResourceManager.GetString("ArchivoNoExiste", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Las Contraseñas no coinciden .
        /// </summary>
        public static string ContrasenasDistintas {
            get {
                return ResourceManager.GetString("ContrasenasDistintas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ha ocurrido un error al subir el archivo, Detalle del error: {0}.
        /// </summary>
        public static string SubidaErronea {
            get {
                return ResourceManager.GetString("SubidaErronea", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El Archivo fue subido y procesado exitosamente.
        /// </summary>
        public static string SubidaExitosa {
            get {
                return ResourceManager.GetString("SubidaExitosa", resourceCulture);
            }
        }
    }
}
