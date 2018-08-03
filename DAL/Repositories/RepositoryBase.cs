 using System;
using System.Collections.Generic;

namespace DAL.Repositories {

 abstract class Repository {
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing) 
        {
            if (!this._disposed) 
            {
                if (disposing) 
                {
                    // clean up resources
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}