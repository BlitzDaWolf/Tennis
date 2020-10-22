using System;
using Tenis_opdracht.DAL;
using Tenis_opdracht.DAL.Context;
using Tenis_opdracht.DAL.Repository;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.BAL
{
    public class UnitOfWork : IDisposable
    {
        public TenisContext context = new TenisContext();

        public UnitOfWork(TenisContext context)
        {
            this.context = context;
        }

        #region private repositorys
        private FineRepository          fineRepository;
        private GameRepository          gameRepository;
        private GameResultRepository    gameResultRepository;
        private GenderRepository        genderRepository;
        private LeagueRepository        leagueRepository;
        private MemberRepository        memberRepository;
        private MemberRoleRepository    memberRoleRepository;
        private RoleRepository          roleRepository;
        #endregion

        #region public repositorys
        public FineRepository FineRepository => this.fineRepository ?? new FineRepository(context);
        public GameRepository GameRepository => this.gameRepository ?? new GameRepository(context);
        public GameResultRepository GameResultRepository => this.gameResultRepository ?? new GameResultRepository(context);
        public GenderRepository GenderRepository => this.genderRepository ?? new GenderRepository(context);
        public LeagueRepository LeagueRepository => this.leagueRepository ?? new LeagueRepository(context);
        public MemberRepository MemberRepository => this.memberRepository?? new MemberRepository(context);
        public MemberRoleRepository MemberRoleRepository => this.memberRoleRepository ?? new MemberRoleRepository(context);
        public RoleRepository RoleRepository => this.roleRepository ?? new RoleRepository(context);
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
                if (disposing)
                {
                    // Dispose all contextes
                    context.Dispose();
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
