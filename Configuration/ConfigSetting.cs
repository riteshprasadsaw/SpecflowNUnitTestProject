using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author: Ritesh Saw
 *	
 *	01-03-2021
 */

namespace SpecflowNUnitTestProject.Configuration
{
    public class ConfigSetting
    {
        public string BrowseType { get; set; }
        public string Ecommerce_Url { get; set; }
        public string Bank_Url { get; set; }

        public string SourceLabs_Username { get; set; }
        public string SourceLabs_AccessKey { get; set; }
    }
}
