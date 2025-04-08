using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordenator.Services.Exceptions {
    public class IntergrityException : ApplicationException {
        public IntergrityException (string message) : base(message) {

        }
    }
}
