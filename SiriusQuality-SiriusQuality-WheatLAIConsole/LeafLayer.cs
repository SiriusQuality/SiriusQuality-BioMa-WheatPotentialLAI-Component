using System;
using System.Collections.Generic;

namespace SiriusQuality_SiriusQuality_WheatLAIConsole
{
    public class LeafLayer // Storage class for leaf layers
    {

        #region fields

        public bool IsSmallPhytomer { get; set; }

        /// <summary>Phyllochron of this Layer</summary>
        public double LayerPhyllochron { get;  set; }

        ///<summary>Period of constant area of leaf i, °CDay</summary>
        public double TTmat { get;  set; }

        ///<summary>Period of senescence of leaf i, °CDay</summary>
        public double TTsen { get;  set; }

        ///<summary> Thermal Time at emergence of leaf layer i</summary>
        public double TTem { get; set; }

        ///<summary>Growth thermal time of layer i</summary>
        public double TTgroLamina { get; set; }

        ///<summary>Layer Green Area Index</summary>
        public double GAI { get { return laminaAI + sheathAI; } }

        ///<summary>Exposed sheath Area Index of this Layer</summary>
        public double sheathAI;

        ///<summary>Leaf lamina Area Index of this Layer</summary>
        public double laminaAI;

        /// <summary>Increment of area index for current day, dimensionless</summary>
        public double DeltaAI { get; set; }

        /// <summary>Change of DM for current day</summary>
        public double DeltaDM { get; set; }

        ///<summary>True if this leaves is dying prematurely because of Ni uptake from mature leaves</summary>
        public bool IsPrematurelyDying { get; protected set; }

        ///<summary>Largest area actually achived by leaf Layer i, dimensionless</summary>
        public double MaxAI { get; /*private*/ set; }

        ///<summary>Current development state of this leaves Layer</summary>
        public LeafState State { get; private set; }

        ///<summary>Lamina Specific Nitrogen (photosyntetically active)</summary>
        public double LaminaSpecificN { get; set; }


        #endregion

        #region Constructors

        /// <summary>Initial constructor</summary>
        /// <param name="universe">The universe of this LeafLayer.</param>
        /// <param name="i">The index of this leaf Layer (0 based index, starts from the bottom of the plant).</param>
        public LeafLayer(double phyllochron,double laminaspecificN, double TTatEmergence)
        {
            LayerPhyllochron = phyllochron;
            LaminaSpecificN = laminaspecificN;
            
            DeltaAI = 0.0;
            DeltaDM = 0.0;
            IsPrematurelyDying = false;
            MaxAI = 0.0;
            State = LeafState.Growing;
            IsSmallPhytomer=false;
            TTmat=0.0;
            TTsen=0.0;
            TTem = TTatEmergence;
            TTgroLamina=0.0;
            sheathAI = 0.0;
            laminaAI = 0.0;

        }

        ///<summary>Copy constructor</summary>
        ///<param name="universe">The universe of this leaf Layer.</param>
        ///<param name="toCopy">The leaf Layer to copy</param>
        public LeafLayer(LeafLayer toCopy)
        {
            LayerPhyllochron = toCopy.LayerPhyllochron;
            LaminaSpecificN = toCopy.LaminaSpecificN;
            DeltaAI = toCopy.DeltaAI;
            DeltaDM = toCopy.DeltaDM;
            IsPrematurelyDying = toCopy.IsPrematurelyDying;
            MaxAI = toCopy.MaxAI;
            State = toCopy.State;
            IsSmallPhytomer = toCopy.IsSmallPhytomer;
            TTmat = toCopy.TTmat;
            TTsen = toCopy.TTsen;
            TTem = toCopy.TTem;
            TTgroLamina = toCopy.TTgroLamina;
            sheathAI  = toCopy.sheathAI;
            laminaAI = toCopy.laminaAI;
        }

        #endregion

        #region Utilities

        public void setState(LeafState newState)
        {
            State = newState;
        }

        public void setPrematurelyDying(int NewIsPrematurelyDying)
        {
            IsPrematurelyDying = NewIsPrematurelyDying == 1;
        }

        #endregion



    }
}