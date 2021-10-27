using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resource.UsableModels
{
    public class CredentialPasswordModel
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
