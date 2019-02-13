namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();


        public double TotalWeight
        {
            get
            {
                double totalWeight = 0;
                if (this.ArsenalParts.Count > 0)
                {
                    totalWeight += this.ArsenalParts.Sum(p => p.Weight);
                }
                if (this.ShellParts.Count > 0)
                {
                    totalWeight += this.ShellParts.Sum(p => p.Weight);
                }
                if (this.EnduranceParts.Count > 0)
                {
                    totalWeight += this.EnduranceParts.Sum(p => p.Weight);
                }
                return totalWeight;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                if (this.ArsenalParts.Count > 0)
                {
                    totalPrice += this.ArsenalParts.Sum(p => p.Price);
                }
                if (this.ShellParts.Count > 0)
                {
                    totalPrice += this.ShellParts.Sum(p => p.Price);
                }
                if (this.EnduranceParts.Count > 0)
                {
                    totalPrice += this.EnduranceParts.Sum(p => p.Price);
                }
                return totalPrice;
            }
        }

        public long TotalAttackModification
        {
            get
            {
                long totalAttackModification = 0;
                if (this.ArsenalParts.Count > 0)
                {
                    totalAttackModification = this.ArsenalParts.Sum(p => p.AttackModifier);
                }
                return totalAttackModification;
            }
            
        }

        public long TotalDefenseModification
        {
            get
            {
                long totalDefenseModification = 0;
                if (this.ShellParts.Count > 0)
                {
                    totalDefenseModification = this.ShellParts.Sum(p => p.DefenseModifier);
                }
                return totalDefenseModification;
            }
        }

        public long TotalHitPointModification
        {
            get
            {
                long totalHitPointModification = 0;
                if (this.EnduranceParts.Count > 0)
                {
                    totalHitPointModification = this.EnduranceParts.Sum(p => p.HitPointsModifier);
                }
                return totalHitPointModification;
            }
        }

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.arsenalParts.Add((IAttackModifyingPart)arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.shellParts.Add((IDefenseModifyingPart)shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.enduranceParts.Add((IHitPointsModifyingPart)endurancePart);
        }
    }
}