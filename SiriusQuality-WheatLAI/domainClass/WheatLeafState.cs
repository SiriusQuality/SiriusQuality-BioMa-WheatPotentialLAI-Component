//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

/// 
/// This class was created from file C:\Users\mancealo\Documents\GitSiriusCode\SiriusCode\Development2\Code\SiriusQuality-WheatLAI\XML\SiriusQualityWheatLAI_WheatLeafState.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inra.fr
/// INRA
/// 
/// 
/// 10/4/2018 11:57:05 AM
/// 
namespace SiriusQualityWheatLAI
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CRA.ModelLayer.Core;
    using CRA.ModelLayer.ParametersManagement;
    
    
    /// <summary>WheatLeafState Domain class contains the accessors to values</summary>
    [Serializable()]
    public class WheatLeafState : ICloneable, IDomainClass
    {
        
        #region Private fields
        private System.Collections.Generic.List<int> _State = new List<int>();
        
        private System.Collections.Generic.List<int> _PreviousState = new List<int>();
        
        private System.Collections.Generic.List<int> _isPrematurelyDying = new List<int>();
        
        private System.Collections.Generic.List<double> _TTGroLamina = new List<double>();
        
        private System.Collections.Generic.List<double> _MaxAI = new List<double>();
        
        private System.Collections.Generic.List<double> _TTsen = new List<double>();
        
        private System.Collections.Generic.List<double> _TTem = new List<double>();
        
        private System.Collections.Generic.List<double> _LaminaAI = new List<double>();
        
        private System.Collections.Generic.List<double> _SheathAI = new List<double>();
        
        private System.Collections.Generic.List<double> _GAI = new List<double>();
        
        private System.Collections.Generic.List<double> _TTmat = new List<double>();
        
        private System.Collections.Generic.List<double> _laminaSpecificN = new List<double>();
        
        private System.Collections.Generic.List<double> _Phyllochron = new List<double>();
        
        private System.Collections.Generic.List<int> _isSmallPhytomer = new List<int>();
        
        private System.Collections.Generic.List<double> _deltaAI = new List<double>();
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public WheatLeafState()
        {
            _parametersIO = new ParametersIO(this);
        }

        public WheatLeafState(WheatLeafState toCopy)
        {

            System.Collections.Generic.List<int> _State = new List<int>(toCopy._State);

            System.Collections.Generic.List<int> _PreviousState = new List<int>(toCopy._PreviousState);

            System.Collections.Generic.List<int> _isPrematurelyDying = new List<int>(toCopy._isPrematurelyDying);

            System.Collections.Generic.List<double> _TTGroLamina = new List<double>(toCopy._TTGroLamina);

            System.Collections.Generic.List<double> _MaxAI = new List<double>(toCopy._MaxAI);

            System.Collections.Generic.List<double> _TTsen = new List<double>(toCopy._TTsen);

            System.Collections.Generic.List<double> _TTem = new List<double>(toCopy._TTem);

            System.Collections.Generic.List<double> _LaminaAI = new List<double>(toCopy._LaminaAI);

            System.Collections.Generic.List<double> _SheathAI = new List<double>(toCopy._SheathAI);

            System.Collections.Generic.List<double> _GAI = new List<double>(toCopy._GAI);

            System.Collections.Generic.List<double> _TTmat = new List<double>(toCopy._TTmat);

            System.Collections.Generic.List<double> _laminaSpecificN = new List<double>(toCopy._laminaSpecificN);

            System.Collections.Generic.List<double> _Phyllochron = new List<double>(toCopy._Phyllochron);

            System.Collections.Generic.List<int> _isSmallPhytomer = new List<int>(toCopy._isSmallPhytomer);

            System.Collections.Generic.List<double> _deltaAI = new List<double>(toCopy._deltaAI);

        }

        #endregion
        
        #region Public properties
        /// <summary>State of the leaf, 0:Growing, 1:Mature,2:Senescing,3:Dead</summary>
        public System.Collections.Generic.List<int> State
        {
            get
            {
                return this._State;
            }
            set
            {
                this._State = value;
            }
        }
        
        /// <summary>Previous State of the leaf, 0:Growing, 1:Mature,2:Senescing,3:Dead</summary>
        public System.Collections.Generic.List<int> PreviousState
        {
            get
            {
                return this._PreviousState;
            }
            set
            {
                this._PreviousState = value;
            }
        }
        
        /// <summary>Flag</summary>
        public System.Collections.Generic.List<int> isPrematurelyDying
        {
            get
            {
                return this._isPrematurelyDying;
            }
            set
            {
                this._isPrematurelyDying = value;
            }
        }
        
        /// <summary>Thermal Time when the Lamina grows</summary>
        public System.Collections.Generic.List<double> TTGroLamina
        {
            get
            {
                return this._TTGroLamina;
            }
            set
            {
                this._TTGroLamina = value;
            }
        }
        
        /// <summary>Largest area actually achieved by leaf Layer</summary>
        public System.Collections.Generic.List<double> MaxAI
        {
            get
            {
                return this._MaxAI;
            }
            set
            {
                this._MaxAI = value;
            }
        }
        
        /// <summary>Thermal Time when Leaf Start Senescing</summary>
        public System.Collections.Generic.List<double> TTsen
        {
            get
            {
                return this._TTsen;
            }
            set
            {
                this._TTsen = value;
            }
        }
        
        /// <summary>Thermal Time at emergence</summary>
        public System.Collections.Generic.List<double> TTem
        {
            get
            {
                return this._TTem;
            }
            set
            {
                this._TTem = value;
            }
        }
        
        /// <summary>Lamina Area Index</summary>
        public System.Collections.Generic.List<double> LaminaAI
        {
            get
            {
                return this._LaminaAI;
            }
            set
            {
                this._LaminaAI = value;
            }
        }
        
        /// <summary>Sheath Area Index</summary>
        public System.Collections.Generic.List<double> SheathAI
        {
            get
            {
                return this._SheathAI;
            }
            set
            {
                this._SheathAI = value;
            }
        }
        
        /// <summary>Green Area Index</summary>
        public System.Collections.Generic.List<double> GAI
        {
            get
            {
                return this._GAI;
            }
            set
            {
                this._GAI = value;
            }
        }
        
        /// <summary>Thermal Time at maturity</summary>
        public System.Collections.Generic.List<double> TTmat
        {
            get
            {
                return this._TTmat;
            }
            set
            {
                this._TTmat = value;
            }
        }
        
        /// <summary>Lamina Specific N</summary>
        public System.Collections.Generic.List<double> laminaSpecificN
        {
            get
            {
                return this._laminaSpecificN;
            }
            set
            {
                this._laminaSpecificN = value;
            }
        }
        
        /// <summary>Leaf layer Phyllochron</summary>
        public System.Collections.Generic.List<double> Phyllochron
        {
            get
            {
                return this._Phyllochron;
            }
            set
            {
                this._Phyllochron = value;
            }
        }
        
        /// <summary>1 if the layer's phytomer is "small"</summary>
        public System.Collections.Generic.List<int> isSmallPhytomer
        {
            get
            {
                return this._isSmallPhytomer;
            }
            set
            {
                this._isSmallPhytomer = value;
            }
        }
        
        /// <summary>Increase of GAI of the day</summary>
        public System.Collections.Generic.List<double> deltaAI
        {
            get
            {
                return this._deltaAI;
            }
            set
            {
                this._deltaAI = value;
            }
        }
        #endregion
        
        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Domain class description";
            }
        }
        
        /// <summary>Domain Class URL</summary>
        public virtual  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Domain Class Properties</summary>
        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass));
            }
        }
        #endregion
        
        /// <summary>Clears the values of the properties of the domain class by using the default value for the type of each property (e.g '0' for numbers, 'the empty string' for strings, etc.)</summary>
        public virtual Boolean ClearValues()
        {
            _State = new List<int>();
            _PreviousState = new List<int>();
            _isPrematurelyDying = new List<int>();
            _TTGroLamina = new List<double>();
            _MaxAI = new List<double>();
            _TTsen = new List<double>();
            _TTem = new List<double>();
            _LaminaAI = new List<double>();
            _SheathAI = new List<double>();
            _GAI = new List<double>();
            _TTmat = new List<double>();
            _laminaSpecificN = new List<double>();
            _Phyllochron = new List<double>();
            _isSmallPhytomer = new List<int>();
            _deltaAI = new List<double>();
            // Returns true if everything is ok
            return true;
        }
        
        #region Clone
        /// <summary>Implement ICloneable.Clone()</summary>
        public virtual Object Clone()
        {
            // Shallow copy by default
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
        #endregion
    }
}
