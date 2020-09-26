using System;
using System.Collections.Generic;
using System.Text;

namespace Tenis_opdracht.BAL
{
    public class UnitOfWork : IDisposable
    {
        public void Save()
        {
            // Save contexts
        }

        #region Disposing
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (!disposing)
                {
                    // Dispose all contextes
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
