using Raiding.Models;

namespace Raiding.Factory
{
    public abstract class Creator
    {
        public abstract IBaseHero HeroFactory();
    }
}