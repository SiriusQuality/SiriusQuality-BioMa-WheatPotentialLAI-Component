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
/// This class was created from file C:\Users\loicm\GitSiriusCode\siriusquality-bioma-wheatpotentiallai-component\SiriusQuality-WheatLAI\XML\SiriusQualityWheatLAI_WheatLAIState.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inrae.fr
/// INRAE
/// 
/// 
/// 20/10/2020 13:24:50
/// 
namespace SiriusQualityWheatLAI
{
    using System;
    using CRA.ModelLayer.Core;
    
    
    /// <summary>WheatLAIStateVarInfoClasses contain the attributes for each variable in the domain class RainData. Attributes are valorized via the static constructor. The data-type VarInfo causes  a dependency to the assembly CRA.Core.Preconditions.dll</summary>
    public class WheatLAIStateVarInfo : IVarInfoClass
    {
        
        #region Private fields
        static VarInfo _newLeafHasAppeared = new VarInfo();
        
        static VarInfo _leafNumber = new VarInfo();
        
        static VarInfo _finalLeafNumber = new VarInfo();
        
        static VarInfo _roundedFinalLeafNumber = new VarInfo();
        
        static VarInfo _phytonum = new VarInfo();
        
        static VarInfo _index = new VarInfo();
        
        static VarInfo _MaximumPotentialLaminaeAI = new VarInfo();
        
        static VarInfo _MaximumPotentialSheathAI = new VarInfo();
        
        static VarInfo _FPAW = new VarInfo();
        
        static VarInfo _isPotentialLAI = new VarInfo();
        
        static VarInfo _VPDairCanopy = new VarInfo();
        
        static VarInfo _DSF = new VarInfo();
        
        static VarInfo _DEF = new VarInfo();
        
        static VarInfo _cumulTTShoot = new VarInfo();
        
        static VarInfo _deltaTTShoot = new VarInfo();
        
        static VarInfo _deltaTTSenescence = new VarInfo();
        
        static VarInfo _incDeltaAreaLimitSF = new VarInfo();
        
        static VarInfo _WaterLimitedPotDeltaAIList = new VarInfo();
        
        static VarInfo _potentialIncDeltaArea = new VarInfo();
        
        static VarInfo _tilleringProfile = new VarInfo();
        
        static VarInfo _leafTillerNumberArray = new VarInfo();
        
        static VarInfo _previousIndex = new VarInfo();
        
        static VarInfo _TTgroSheathList = new VarInfo();
        
        static VarInfo _TT = new VarInfo();
        
        static VarInfo _dayLength = new VarInfo();
        
        static VarInfo _avHourVPDDay = new VarInfo();
        
        static VarInfo _availableN = new VarInfo();
        
        static VarInfo _incDeltaArea = new VarInfo();
        #endregion
        
        /// <summary>Constructor</summary>
        static WheatLAIStateVarInfo()
        {
            WheatLAIStateVarInfo.DescribeVariables();
        }
        
        #region IVarInfoClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "Domain class description";
            }
        }
        
        /// <summary>Reference to the ontology</summary>
        public  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Value domain class of reference</summary>
        public  string DomainClassOfReference
        {
            get
            {
                return "WheatLAIState";
            }
        }
        #endregion
        
        #region Public properties
        /// <summary>0: if no leaf has appeared, 1 if a leaf has just appeared</summary>
        public static  VarInfo newLeafHasAppeared
        {
            get
            {
                return  _newLeafHasAppeared;
            }
        }
        
        /// <summary>Number of emerged leaves on the main-stem</summary>
        public static  VarInfo leafNumber
        {
            get
            {
                return  _leafNumber;
            }
        }
        
        /// <summary> Leaf numer at maturity</summary>
        public static  VarInfo finalLeafNumber
        {
            get
            {
                return  _finalLeafNumber;
            }
        }
        
        /// <summary>rounded leaf number at maturity</summary>
        public static  VarInfo roundedFinalLeafNumber
        {
            get
            {
                return  _roundedFinalLeafNumber;
            }
        }
        
        /// <summary>Number of leaf layer created</summary>
        public static  VarInfo phytonum
        {
            get
            {
                return  _phytonum;
            }
        }
        
        /// <summary>index of the  last  leaf layer created</summary>
        public static  VarInfo index
        {
            get
            {
                return  _index;
            }
        }
        
        /// <summary>Maximum allowed Lamina area index without stress effects</summary>
        public static  VarInfo MaximumPotentialLaminaeAI
        {
            get
            {
                return  _MaximumPotentialLaminaeAI;
            }
        }
        
        /// <summary>Maximum Sheat area index allowed without stress effect</summary>
        public static  VarInfo MaximumPotentialSheathAI
        {
            get
            {
                return  _MaximumPotentialSheathAI;
            }
        }
        
        /// <summary>Fraction of plant available water</summary>
        public static  VarInfo FPAW
        {
            get
            {
                return  _FPAW;
            }
        }
        
        /// <summary>0: no drought stress is applied, 1: drought stress is applied</summary>
        public static  VarInfo isPotentialLAI
        {
            get
            {
                return  _isPotentialLAI;
            }
        }
        
        /// <summary>Vapour Pressur deficit Air-Canopy</summary>
        public static  VarInfo VPDairCanopy
        {
            get
            {
                return  _VPDairCanopy;
            }
        }
        
        /// <summary>drought senescence factor</summary>
        public static  VarInfo DSF
        {
            get
            {
                return  _DSF;
            }
        }
        
        /// <summary>drought expansion factor</summary>
        public static  VarInfo DEF
        {
            get
            {
                return  _DEF;
            }
        }
        
        /// <summary>Cumulative Shoot thermal time</summary>
        public static  VarInfo cumulTTShoot
        {
            get
            {
                return  _cumulTTShoot;
            }
        }
        
        /// <summary>Increas of shoot thermal time for the day</summary>
        public static  VarInfo deltaTTShoot
        {
            get
            {
                return  _deltaTTShoot;
            }
        }
        
        /// <summary>Increase of senescence thermal time for the day</summary>
        public static  VarInfo deltaTTSenescence
        {
            get
            {
                return  _deltaTTSenescence;
            }
        }
        
        /// <summary>Total daily increase of GAI under drought stress</summary>
        public static  VarInfo incDeltaAreaLimitSF
        {
            get
            {
                return  _incDeltaAreaLimitSF;
            }
        }
        
        /// <summary>list on each phytomer for the potential daily increase of leaf layer</summary>
        public static  VarInfo WaterLimitedPotDeltaAIList
        {
            get
            {
                return  _WaterLimitedPotDeltaAIList;
            }
        }
        
        /// <summary>Total daily increase in GAI without stress</summary>
        public static  VarInfo potentialIncDeltaArea
        {
            get
            {
                return  _potentialIncDeltaArea;
            }
        }
        
        /// <summary>store the amount of new tiller created at each time a new tiller appears</summary>
        public static  VarInfo tilleringProfile
        {
            get
            {
                return  _tilleringProfile;
            }
        }
        
        /// <summary>store the number of tiller for each leaf layer</summary>
        public static  VarInfo leafTillerNumberArray
        {
            get
            {
                return  _leafTillerNumberArray;
            }
        }
        
        /// <summary>index of the leaf layer during the last call of the component</summary>
        public static  VarInfo previousIndex
        {
            get
            {
                return  _previousIndex;
            }
        }
        
        /// <summary>List of Thermal Time at end of the sheath growth</summary>
        public static  VarInfo TTgroSheathList
        {
            get
            {
                return  _TTgroSheathList;
            }
        }
        
        /// <summary>List of Thermal times since emergence of this leaf Layer</summary>
        public static  VarInfo TT
        {
            get
            {
                return  _TT;
            }
        }
        
        /// <summary>Lenght of the day</summary>
        public static  VarInfo dayLength
        {
            get
            {
                return  _dayLength;
            }
        }
        
        /// <summary>Average VPD during the day</summary>
        public static  VarInfo avHourVPDDay
        {
            get
            {
                return  _avHourVPDDay;
            }
        }
        
        /// <summary>Available Nitrogen of the day</summary>
        public static  VarInfo availableN
        {
            get
            {
                return  _availableN;
            }
        }
        
        /// <summary>Actual increase in Area of the day</summary>
        public static  VarInfo incDeltaArea
        {
            get
            {
                return  _incDeltaArea;
            }
        }
        #endregion
        
        #region VarInfo values
        /// <summary>Set VarInfo values</summary>
        static void DescribeVariables()
        {
            //   
            _newLeafHasAppeared.Name = "newLeafHasAppeared";
            _newLeafHasAppeared.Description = "0: if no leaf has appeared, 1 if a leaf has just appeared";
            _newLeafHasAppeared.MaxValue = 1D;
            _newLeafHasAppeared.MinValue = 0D;
            _newLeafHasAppeared.DefaultValue = 0D;
            _newLeafHasAppeared.Units = "NA";
            _newLeafHasAppeared.URL = "http://";
            _newLeafHasAppeared.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _leafNumber.Name = "leafNumber";
            _leafNumber.Description = "Number of emerged leaves on the main-stem";
            _leafNumber.MaxValue = 20D;
            _leafNumber.MinValue = 0D;
            _leafNumber.DefaultValue = 0D;
            _leafNumber.Units = "leaf";
            _leafNumber.URL = "http://";
            _leafNumber.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _finalLeafNumber.Name = "finalLeafNumber";
            _finalLeafNumber.Description = " Leaf numer at maturity";
            _finalLeafNumber.MaxValue = 20D;
            _finalLeafNumber.MinValue = 0D;
            _finalLeafNumber.DefaultValue = 10D;
            _finalLeafNumber.Units = "leaf";
            _finalLeafNumber.URL = "http://";
            _finalLeafNumber.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _roundedFinalLeafNumber.Name = "roundedFinalLeafNumber";
            _roundedFinalLeafNumber.Description = "rounded leaf number at maturity";
            _roundedFinalLeafNumber.MaxValue = 20D;
            _roundedFinalLeafNumber.MinValue = 0D;
            _roundedFinalLeafNumber.DefaultValue = 10D;
            _roundedFinalLeafNumber.Units = "leaf";
            _roundedFinalLeafNumber.URL = "http://";
            _roundedFinalLeafNumber.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _phytonum.Name = "phytonum";
            _phytonum.Description = "Number of leaf layer created";
            _phytonum.MaxValue = 21D;
            _phytonum.MinValue = 1D;
            _phytonum.DefaultValue = 1D;
            _phytonum.Units = "-";
            _phytonum.URL = "http://";
            _phytonum.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _index.Name = "index";
            _index.Description = "index of the  last  leaf layer created";
            _index.MaxValue = 20D;
            _index.MinValue = 0D;
            _index.DefaultValue = 0D;
            _index.Units = "-";
            _index.URL = "http://";
            _index.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _MaximumPotentialLaminaeAI.Name = "MaximumPotentialLaminaeAI";
            _MaximumPotentialLaminaeAI.Description = "Maximum allowed Lamina area index without stress effects";
            _MaximumPotentialLaminaeAI.MaxValue = 100D;
            _MaximumPotentialLaminaeAI.MinValue = 0D;
            _MaximumPotentialLaminaeAI.DefaultValue = 0D;
            _MaximumPotentialLaminaeAI.Units = "m²/m²";
            _MaximumPotentialLaminaeAI.URL = "http://";
            _MaximumPotentialLaminaeAI.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _MaximumPotentialSheathAI.Name = "MaximumPotentialSheathAI";
            _MaximumPotentialSheathAI.Description = "Maximum Sheat area index allowed without stress effect";
            _MaximumPotentialSheathAI.MaxValue = 100D;
            _MaximumPotentialSheathAI.MinValue = 0D;
            _MaximumPotentialSheathAI.DefaultValue = 0D;
            _MaximumPotentialSheathAI.Units = "m²/m²";
            _MaximumPotentialSheathAI.URL = "http://";
            _MaximumPotentialSheathAI.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _FPAW.Name = "FPAW";
            _FPAW.Description = "Fraction of plant available water";
            _FPAW.MaxValue = 1D;
            _FPAW.MinValue = 0D;
            _FPAW.DefaultValue = 0.5D;
            _FPAW.Units = "dimensionless";
            _FPAW.URL = "http://";
            _FPAW.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _isPotentialLAI.Name = "isPotentialLAI";
            _isPotentialLAI.Description = "0: no drought stress is applied, 1: drought stress is applied";
            _isPotentialLAI.MaxValue = 1D;
            _isPotentialLAI.MinValue = 0D;
            _isPotentialLAI.DefaultValue = 0D;
            _isPotentialLAI.Units = "-";
            _isPotentialLAI.URL = "http://";
            _isPotentialLAI.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _VPDairCanopy.Name = "VPDairCanopy";
            _VPDairCanopy.Description = "Vapour Pressur deficit Air-Canopy";
            _VPDairCanopy.MaxValue = 100D;
            _VPDairCanopy.MinValue = 0D;
            _VPDairCanopy.DefaultValue = 0D;
            _VPDairCanopy.Units = "hPa";
            _VPDairCanopy.URL = "http://";
            _VPDairCanopy.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _DSF.Name = "DSF";
            _DSF.Description = "drought senescence factor";
            _DSF.MaxValue = 10D;
            _DSF.MinValue = 0D;
            _DSF.DefaultValue = 0D;
            _DSF.Units = "-";
            _DSF.URL = "http://";
            _DSF.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _DEF.Name = "DEF";
            _DEF.Description = "drought expansion factor";
            _DEF.MaxValue = 10D;
            _DEF.MinValue = 0D;
            _DEF.DefaultValue = 0D;
            _DEF.Units = "-";
            _DEF.URL = "http://";
            _DEF.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _cumulTTShoot.Name = "cumulTTShoot";
            _cumulTTShoot.Description = "Cumulative Shoot thermal time";
            _cumulTTShoot.MaxValue = 1000D;
            _cumulTTShoot.MinValue = 0D;
            _cumulTTShoot.DefaultValue = 0D;
            _cumulTTShoot.Units = "°C/d";
            _cumulTTShoot.URL = "http://";
            _cumulTTShoot.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _deltaTTShoot.Name = "deltaTTShoot";
            _deltaTTShoot.Description = "Increas of shoot thermal time for the day";
            _deltaTTShoot.MaxValue = 50D;
            _deltaTTShoot.MinValue = 0D;
            _deltaTTShoot.DefaultValue = 0D;
            _deltaTTShoot.Units = "°C/d";
            _deltaTTShoot.URL = "http://";
            _deltaTTShoot.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _deltaTTSenescence.Name = "deltaTTSenescence";
            _deltaTTSenescence.Description = "Increase of senescence thermal time for the day";
            _deltaTTSenescence.MaxValue = 50D;
            _deltaTTSenescence.MinValue = 0D;
            _deltaTTSenescence.DefaultValue = 0D;
            _deltaTTSenescence.Units = "°C/d";
            _deltaTTSenescence.URL = "http://";
            _deltaTTSenescence.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _incDeltaAreaLimitSF.Name = "incDeltaAreaLimitSF";
            _incDeltaAreaLimitSF.Description = "Total daily increase of GAI under drought stress";
            _incDeltaAreaLimitSF.MaxValue = 1D;
            _incDeltaAreaLimitSF.MinValue = 0D;
            _incDeltaAreaLimitSF.DefaultValue = 0D;
            _incDeltaAreaLimitSF.Units = "m²/m²";
            _incDeltaAreaLimitSF.URL = "http://";
            _incDeltaAreaLimitSF.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _WaterLimitedPotDeltaAIList.Name = "WaterLimitedPotDeltaAIList";
            _WaterLimitedPotDeltaAIList.Description = "list on each phytomer for the potential daily increase of leaf layer";
            _WaterLimitedPotDeltaAIList.MaxValue = 0D;
            _WaterLimitedPotDeltaAIList.MinValue = 0D;
            _WaterLimitedPotDeltaAIList.DefaultValue = 0D;
            _WaterLimitedPotDeltaAIList.Units = "m²/m²";
            _WaterLimitedPotDeltaAIList.URL = "http://";
            _WaterLimitedPotDeltaAIList.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _potentialIncDeltaArea.Name = "potentialIncDeltaArea";
            _potentialIncDeltaArea.Description = "Total daily increase in GAI without stress";
            _potentialIncDeltaArea.MaxValue = 10D;
            _potentialIncDeltaArea.MinValue = 0D;
            _potentialIncDeltaArea.DefaultValue = 0D;
            _potentialIncDeltaArea.Units = "m²/m²";
            _potentialIncDeltaArea.URL = "http://";
            _potentialIncDeltaArea.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _tilleringProfile.Name = "tilleringProfile";
            _tilleringProfile.Description = "store the amount of new tiller created at each time a new tiller appears";
            _tilleringProfile.MaxValue = 0D;
            _tilleringProfile.MinValue = 0D;
            _tilleringProfile.DefaultValue = 0D;
            _tilleringProfile.Units = "shoot/m²";
            _tilleringProfile.URL = "http://";
            _tilleringProfile.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _leafTillerNumberArray.Name = "leafTillerNumberArray";
            _leafTillerNumberArray.Description = "store the number of tiller for each leaf layer";
            _leafTillerNumberArray.MaxValue = 0D;
            _leafTillerNumberArray.MinValue = 0D;
            _leafTillerNumberArray.DefaultValue = 0D;
            _leafTillerNumberArray.Units = "shoot";
            _leafTillerNumberArray.URL = "http://";
            _leafTillerNumberArray.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _previousIndex.Name = "previousIndex";
            _previousIndex.Description = "index of the leaf layer during the last call of the component";
            _previousIndex.MaxValue = 20D;
            _previousIndex.MinValue = 0D;
            _previousIndex.DefaultValue = 0D;
            _previousIndex.Units = "dimensioonless";
            _previousIndex.URL = "http://";
            _previousIndex.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            //   
            _TTgroSheathList.Name = "TTgroSheathList";
            _TTgroSheathList.Description = "List of Thermal Time at end of the sheath growth";
            _TTgroSheathList.MaxValue = 3000D;
            _TTgroSheathList.MinValue = 0D;
            _TTgroSheathList.DefaultValue = 0D;
            _TTgroSheathList.Units = "°Cd";
            _TTgroSheathList.URL = "http://";
            _TTgroSheathList.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _TT.Name = "TT";
            _TT.Description = "List of Thermal times since emergence of this leaf Layer";
            _TT.MaxValue = 3000D;
            _TT.MinValue = 0D;
            _TT.DefaultValue = 0D;
            _TT.Units = "°Cd";
            _TT.URL = "http://";
            _TT.ValueType = VarInfoValueTypes.GetInstanceForName("ListDouble");
            //   
            _dayLength.Name = "dayLength";
            _dayLength.Description = "Lenght of the day";
            _dayLength.MaxValue = 24D;
            _dayLength.MinValue = 0D;
            _dayLength.DefaultValue = 12D;
            _dayLength.Units = "h";
            _dayLength.URL = "http://";
            _dayLength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _avHourVPDDay.Name = "avHourVPDDay";
            _avHourVPDDay.Description = "Average VPD during the day";
            _avHourVPDDay.MaxValue = 100D;
            _avHourVPDDay.MinValue = 0D;
            _avHourVPDDay.DefaultValue = 0D;
            _avHourVPDDay.Units = "hPa";
            _avHourVPDDay.URL = "http://";
            _avHourVPDDay.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _availableN.Name = "availableN";
            _availableN.Description = "Available Nitrogen of the day";
            _availableN.MaxValue = 1000D;
            _availableN.MinValue = 0D;
            _availableN.DefaultValue = 10D;
            _availableN.Units = "g/m²";
            _availableN.URL = "http://";
            _availableN.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            //   
            _incDeltaArea.Name = "incDeltaArea";
            _incDeltaArea.Description = "Actual increase in Area of the day";
            _incDeltaArea.MaxValue = 1000D;
            _incDeltaArea.MinValue = 0D;
            _incDeltaArea.DefaultValue = 0D;
            _incDeltaArea.Units = "m²/m²";
            _incDeltaArea.URL = "http://";
            _incDeltaArea.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }
        #endregion
    }
}
