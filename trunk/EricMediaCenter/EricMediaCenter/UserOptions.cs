using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace EricMediaCenter
{
    /// <summary>
    ///   Provides information and serialization of user options.
    /// </summary>
    /// <remarks>
    ///   Use the <b>UserOptions</b> to set and <see cref="Save"/>
    ///   options that are specific to a user.  To access an option always use the <see cref="Current"/>
    ///   property, which returns an instance of the class.  For example <c>UserOptions.Current.StartLocation</c>.
    ///   <para>
    ///   All the properties of <b>UserOptions</b> are maintained in an XML file.  The path
    ///   to the XML file is
    ///   "<see cref="Environment.SpecialFolder">ApplicationData</see>\
    ///    <see cref="Application.CompanyName"/>\ 
    ///    <see cref="Application.ProductName"/>\ 
    ///    <i>appname</i>.options.xml".
    ///    A typical path is
    ///    "C:\Documents and Settings\<i>username</i>\Application Data\<i>company</i>\<i>product</i>\<i>appname</i>.exe.options.xml".
    ///    </para>
    ///    <para>
    ///    If security policy does not allow access to the <see cref="Environment.SpecialFolder">ApplicationData</see>
    ///    folder, then the <b>UserOptions</b> are only maintained during the lifetime of the application.
    ///    </para>
    /// </remarks>
    public class UserOptions
    {

        private static UserOptions current;

        #region Constructor
        /// <summary>
        ///   Creates a new instance of the <see cref="UserOptions"/> class.
        /// </summary>
        /// <remarks>
        ///   This method is internal to serialization.  You should always use the
        ///   <see cref="Current"/> static property to obtain the <b>UserOptions</b>.
        /// </remarks>
        public UserOptions()
        {
        }
        #endregion

        #region Properties (User options)

        #endregion

        #region Static Properties
        /// <summary>
        ///   Gets the current <see cref="UserOptions"/> for the application.
        /// </summary>
        /// <value>
        ///   A <see cref="UserOptions"/> for the current user.
        /// </value>
        /// <remarks>
        ///   <b>Current</b> will load the user options file if required.  If a <see cref="SecurityException"/>
        ///   is encounter, then the default options, as per the constructor, is used.
        /// </remarks>
        public static UserOptions Current
        {
            get
            {
                if (current == null)
                {
                    lock (typeof(UserOptions))
                    {
                        if (current == null)
                        {
                            try
                            {
                                current = Load();
                            }
                            catch (SecurityException)
                            {
                                current = new UserOptions();
                            }
                        }
                    }
                }
                return current;
            }
        }
        #endregion

        #region Serialization
        /// <summary>
        ///   Loads a the <b>UserOptions</b> file into a new instance.
        /// </summary>
        /// <returns>
        ///   A <see cref="UserOptions"/>.
        /// </returns>
        private static UserOptions Load()
        {
            if (!File.Exists(OptionsPath))
                return new UserOptions();
            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(UserOptions));
                using (FileStream stream = new FileStream(OptionsPath, FileMode.Open))
                {
                    XmlReader reader = new XmlTextReader(stream);
                    return (UserOptions)serializer.Deserialize(reader);
                }
            }
            catch
            {
                return new UserOptions();
            }
        }

        /// <summary>
        ///   Saves the <see cref="UserOptions"/>
        /// </summary>
        /// <remarks>
        ///   A <see cref="SecurityException"/> is quietly ignored.
        /// </remarks>
        public void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (StreamWriter writer = new StreamWriter(OptionsPath))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch
            {
                // Do nothing.
            }
        }

        /// <summary>
        ///   Gets the fully qualified name of the ".options.xml" file.
        /// </summary>
        /// <remarks>
        ///   If a path does not exist, one is created in the following format:
        ///   <para>
        ///   <see cref="Environment.SpecialFolder">ApplicationData</see>\
        ///    <see cref="Application.CompanyName"/>\ 
        ///    <see cref="Application.ProductName"/>\ 
        ///    <i>appname</i>.options.xml
        ///   </para>
        ///   <para>
        ///    A typical <b>OptionsPath</b>, is 
        ///    "C:\Documents and Settings\<i>username</i>\Application Data\<i>company</i>\<i>product</i>\<i>appname</i>.exe.options.xml".
        ///    </para>
        /// </remarks>
        private static string OptionsPath
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                path.Append(Path.DirectorySeparatorChar);
                path.Append("Eric Media Center");
                lock (typeof(UserOptions))
                {
                    string dir = path.ToString();
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }

                // Add the file name.
                path.Append(Path.DirectorySeparatorChar);
                path.Append(Path.GetFileName(Application.ExecutablePath));
                path.Append(@".options.xml");

                return path.ToString();
            }
        }
        #endregion
    }
}
