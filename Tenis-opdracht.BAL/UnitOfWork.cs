using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.DAL;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.Data;

namespace Tenis_opdracht.BAL
{
    public class UnitOfWork : IDisposable
    {
        public TenisContext context = new TenisContext();

        public UnitOfWork() { }
        public UnitOfWork(TenisContext context)
        {
            this.context = context;
        }

        #region private repositorys
        private GenericRepository<Gender> genderRepository;
        private GenericRepository<MemberRole> memberRoleRepository;
        private GenericRepository<Member> memberRepository;
        private GenericRepository<Role> roleRepository;
        #endregion

        #region public repositorys
        public GenericRepository<Gender> GenderRepository => this.genderRepository ?? new GenericRepository<Gender>(context);
        public GenericRepository<MemberRole> MemberRoleRepository => this.memberRoleRepository ?? new GenericRepository<MemberRole>(context);
        public GenericRepository<Member> MemberRepository => this.memberRepository ?? new GenericRepository<Member>(context);
        public GenericRepository<Role> RoleRepository => this.roleRepository ?? new GenericRepository<Role>(context);
        #endregion

        public void Save()
        {
            context.SaveChanges();
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
