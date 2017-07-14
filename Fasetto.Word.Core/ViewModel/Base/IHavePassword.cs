using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// An interface for a class that acn provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The Secure Password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
