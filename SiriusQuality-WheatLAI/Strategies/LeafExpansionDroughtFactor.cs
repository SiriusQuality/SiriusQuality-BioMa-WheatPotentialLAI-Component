

 //Author:pierre martre pierre.martre@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:7/26/2018
 //Date of revision:

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;


using SiriusQualityWheatLAI;
using CRA.AgroManagement;


//To make this project compile please add the reference to assembly: SiriusQuality-WheatLAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace SiriusQualityWheatLAI.Strategies
{

	/// <summary>
	///Class LeafExpansionDroughtFactor
    /// 
    /// </summary>
	public class LeafExpansionDroughtFactor : IStrategySiriusQualityWheatLAI
	{

	#region Constructor

			public LeafExpansionDroughtFactor()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 0.1;
				 v1.Description = "Fraction of plant available water below which the rate of leaf expansion equals zer";
				 v1.Id = 0;
				 v1.MaxValue = 1;
				 v1.MinValue = 0;
				 v1.Name = "LowerFPAWexp";
				 v1.Size = 1;
				 v1.Units = "dimensionless";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 0.5;
				 v2.Description = "Fraction of plant available water threshold below which the rate of leaf expansion starts to decrease";
				 v2.Id = 0;
				 v2.MaxValue = 1;
				 v2.MinValue = 0;
				 v2.Name = "UpperFPAWexp";
				 v2.Size = 1;
				 v2.Units = "dimensionless";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				VarInfo v3 = new VarInfo();
				 v3.DefaultValue = 4.5;
				 v3.Description = "Maximum rate of acceleration of leaf senescence in response to soil water deficit";
				 v3.Id = 0;
				 v3.MaxValue = 100;
				 v3.MinValue = 0;
				 v3.Name = "MaxDSF";
				 v3.Size = 1;
				 v3.Units = "dimensionless";
				 v3.URL = "";
				 v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v3);
				VarInfo v4 = new VarInfo();
				 v4.DefaultValue = 0.1;
				 v4.Description = "Fraction of plant available water value below which DSFmax is reached";
				 v4.Id = 0;
				 v4.MaxValue = 1;
				 v4.MinValue = 0;
				 v4.Name = "LowerFPAWsen";
				 v4.Size = 1;
				 v4.Units = "dimensionless";
				 v4.URL = "";
				 v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v4);
				VarInfo v5 = new VarInfo();
				 v5.DefaultValue = 0.4;
				 v5.Description = "Fraction of plant available water threshold below which the rate of leaf senescence starts to accelerate";
				 v5.Id = 0;
				 v5.MaxValue = 1;
				 v5.MinValue = 0;
				 v5.Name = "UpperFPAWsen";
				 v5.Size = 1;
				 v5.Units = "dimensionless";
				 v5.URL = "";
				 v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v5);
				VarInfo v6 = new VarInfo();
				 v6.DefaultValue = 45;
				 v6.Description = "Canopy-to-air VPD below which the rate of leaf expansion equals zero and the rate of leaf senescence is maximum";
				 v6.Id = 0;
				 v6.MaxValue = 100;
				 v6.MinValue = 0;
				 v6.Name = "UpperVPD";
				 v6.Size = 1;
				 v6.Units = "hPa";
				 v6.URL = "";
				 v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v6.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v6);
				VarInfo v7 = new VarInfo();
				 v7.DefaultValue = 15;
				 v7.Description = "Canopy-to-air VPD threshold above which the rate of leaf expansion strats to decreaseand the rate of leaf senescence starts to increase";
				 v7.Id = 0;
				 v7.MaxValue = 100;
				 v7.MinValue = 0;
				 v7.Name = "LowerVPD";
				 v7.Size = 1;
				 v7.Units = "hPa";
				 v7.URL = "";
				 v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v7.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v7);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd1.PropertyName = "FPAW";
				pd1.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.FPAW)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.FPAW);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd2.PropertyName = "isPotentialLAI";
				pd2.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.isPotentialLAI)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.isPotentialLAI);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd3.PropertyName = "VPDairCanopy";
				pd3.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.VPDairCanopy)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.VPDairCanopy);
				_inputs0_0.Add(pd3);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd4.PropertyName = "DSF";
				pd4.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF);
				_outputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd5.PropertyName = "DEF";
				pd5.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF);
				_outputs0_0.Add(pd5);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager
				_modellingOptionsManager = new ModellingOptionsManager(mo0_0);
			
				SetStaticParametersVarInfoDefinitions();
				SetPublisherData();
					
			}

	#endregion

	#region Implementation of IAnnotatable

			/// <summary>
			/// Description of the model
			/// </summary>
			public string Description
			{
				get { return ""; }
			}
			
			/// <summary>
			/// URL to access the description of the model
			/// </summary>
			public string URL
			{
				get { return "http://biomamodelling.org"; }
			}
		

	#endregion
	
	#region Implementation of IStrategy

			/// <summary>
			/// Domain of the model.
			/// </summary>
			public string Domain
			{
				get {  return "Crop"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return ""; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
			}

			/// <summary>
			/// Timestep to be used with this strategy
			/// </summary>
			public IList<int> TimeStep
			{
				get
				{
					IList<int> ts = new List<int>();
					
					return ts;
				}
			}
	
	
	#region Publisher Data

			private PublisherData _pd;
			private  void SetPublisherData()
			{
					// Set publishers' data
					
				_pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
				_pd.Add("Creator", "pierre.martre@inra.fr");
				_pd.Add("Date", "7/26/2018");
				_pd.Add("Publisher", "INRA");
			}

			public PublisherData PublisherData
			{
				get { return _pd; }
			}

	#endregion

	#region ModellingOptionsManager

			private ModellingOptionsManager _modellingOptionsManager;
			
			public ModellingOptionsManager ModellingOptionsManager
			{
				get { return _modellingOptionsManager; }            
			}

	#endregion

			/// <summary>
			/// Return the types of the domain classes used by the strategy
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Type> GetStrategyDomainClassesTypes()
			{
				return new List<Type>() {  typeof(SiriusQualityWheatLAI.WheatLAIState),typeof(SiriusQualityWheatLAI.WheatLeafState),typeof(SiriusQualityWheatLAI.WheatLeafState),typeof(CRA.AgroManagement.ActEvents) };
			}

	#endregion

    #region Instances of the parameters
			
			// Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

			
			public Double LowerFPAWexp
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LowerFPAWexp");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LowerFPAWexp' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LowerFPAWexp");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LowerFPAWexp' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double UpperFPAWexp
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("UpperFPAWexp");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'UpperFPAWexp' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("UpperFPAWexp");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'UpperFPAWexp' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double MaxDSF
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("MaxDSF");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'MaxDSF' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("MaxDSF");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'MaxDSF' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double LowerFPAWsen
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LowerFPAWsen");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LowerFPAWsen' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LowerFPAWsen");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LowerFPAWsen' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double UpperFPAWsen
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("UpperFPAWsen");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'UpperFPAWsen' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("UpperFPAWsen");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'UpperFPAWsen' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double UpperVPD
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("UpperVPD");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'UpperVPD' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("UpperVPD");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'UpperVPD' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}
			public Double LowerVPD
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LowerVPD");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LowerVPD' not found (or found null) in strategy 'LeafExpansionDroughtFactor'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LowerVPD");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LowerVPD' not found in strategy 'LeafExpansionDroughtFactor'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				 

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
					//Code written below will not be overwritten by a future code generation

					//Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
            }

	#endregion		

	#region Static parameters VarInfo definition

			// Define the properties of the static VarInfo of the parameters
			private static void SetStaticParametersVarInfoDefinitions()
			{                                
                LowerFPAWexpVarInfo.Name = "LowerFPAWexp";
				LowerFPAWexpVarInfo.Description =" Fraction of plant available water below which the rate of leaf expansion equals zer";
				LowerFPAWexpVarInfo.MaxValue = 1;
				LowerFPAWexpVarInfo.MinValue = 0;
				LowerFPAWexpVarInfo.DefaultValue = 0.1;
				LowerFPAWexpVarInfo.Units = "dimensionless";
				LowerFPAWexpVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				UpperFPAWexpVarInfo.Name = "UpperFPAWexp";
				UpperFPAWexpVarInfo.Description =" Fraction of plant available water threshold below which the rate of leaf expansion starts to decrease";
				UpperFPAWexpVarInfo.MaxValue = 1;
				UpperFPAWexpVarInfo.MinValue = 0;
				UpperFPAWexpVarInfo.DefaultValue = 0.5;
				UpperFPAWexpVarInfo.Units = "dimensionless";
				UpperFPAWexpVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				MaxDSFVarInfo.Name = "MaxDSF";
				MaxDSFVarInfo.Description =" Maximum rate of acceleration of leaf senescence in response to soil water deficit";
				MaxDSFVarInfo.MaxValue = 100;
				MaxDSFVarInfo.MinValue = 0;
				MaxDSFVarInfo.DefaultValue = 4.5;
				MaxDSFVarInfo.Units = "dimensionless";
				MaxDSFVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				LowerFPAWsenVarInfo.Name = "LowerFPAWsen";
				LowerFPAWsenVarInfo.Description =" Fraction of plant available water value below which DSFmax is reached";
				LowerFPAWsenVarInfo.MaxValue = 1;
				LowerFPAWsenVarInfo.MinValue = 0;
				LowerFPAWsenVarInfo.DefaultValue = 0.1;
				LowerFPAWsenVarInfo.Units = "dimensionless";
				LowerFPAWsenVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				UpperFPAWsenVarInfo.Name = "UpperFPAWsen";
				UpperFPAWsenVarInfo.Description =" Fraction of plant available water threshold below which the rate of leaf senescence starts to accelerate";
				UpperFPAWsenVarInfo.MaxValue = 1;
				UpperFPAWsenVarInfo.MinValue = 0;
				UpperFPAWsenVarInfo.DefaultValue = 0.4;
				UpperFPAWsenVarInfo.Units = "dimensionless";
				UpperFPAWsenVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				UpperVPDVarInfo.Name = "UpperVPD";
				UpperVPDVarInfo.Description =" Canopy-to-air VPD below which the rate of leaf expansion equals zero and the rate of leaf senescence is maximum";
				UpperVPDVarInfo.MaxValue = 100;
				UpperVPDVarInfo.MinValue = 0;
				UpperVPDVarInfo.DefaultValue = 45;
				UpperVPDVarInfo.Units = "hPa";
				UpperVPDVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				LowerVPDVarInfo.Name = "LowerVPD";
				LowerVPDVarInfo.Description =" Canopy-to-air VPD threshold above which the rate of leaf expansion strats to decreaseand the rate of leaf senescence starts to increase";
				LowerVPDVarInfo.MaxValue = 100;
				LowerVPDVarInfo.MinValue = 0;
				LowerVPDVarInfo.DefaultValue = 15;
				LowerVPDVarInfo.Units = "hPa";
				LowerVPDVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _LowerFPAWexpVarInfo= new VarInfo();
				/// <summary> 
				///LowerFPAWexp VarInfo definition
				/// </summary>
				public static VarInfo LowerFPAWexpVarInfo
				{
					get { return _LowerFPAWexpVarInfo; }
				}
				private static VarInfo _UpperFPAWexpVarInfo= new VarInfo();
				/// <summary> 
				///UpperFPAWexp VarInfo definition
				/// </summary>
				public static VarInfo UpperFPAWexpVarInfo
				{
					get { return _UpperFPAWexpVarInfo; }
				}
				private static VarInfo _MaxDSFVarInfo= new VarInfo();
				/// <summary> 
				///MaxDSF VarInfo definition
				/// </summary>
				public static VarInfo MaxDSFVarInfo
				{
					get { return _MaxDSFVarInfo; }
				}
				private static VarInfo _LowerFPAWsenVarInfo= new VarInfo();
				/// <summary> 
				///LowerFPAWsen VarInfo definition
				/// </summary>
				public static VarInfo LowerFPAWsenVarInfo
				{
					get { return _LowerFPAWsenVarInfo; }
				}
				private static VarInfo _UpperFPAWsenVarInfo= new VarInfo();
				/// <summary> 
				///UpperFPAWsen VarInfo definition
				/// </summary>
				public static VarInfo UpperFPAWsenVarInfo
				{
					get { return _UpperFPAWsenVarInfo; }
				}
				private static VarInfo _UpperVPDVarInfo= new VarInfo();
				/// <summary> 
				///UpperVPD VarInfo definition
				/// </summary>
				public static VarInfo UpperVPDVarInfo
				{
					get { return _UpperVPDVarInfo; }
				}
				private static VarInfo _LowerVPDVarInfo= new VarInfo();
				/// <summary> 
				///LowerVPD VarInfo definition
				/// </summary>
				public static VarInfo LowerVPDVarInfo
				{
					get { return _LowerVPDVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
						

	#endregion
	
	#region pre/post conditions management		

		    /// <summary>
			/// Test to verify the postconditions
			/// </summary>
			public string TestPostConditions(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF.CurrentValue=wheatlaistate.DSF;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF.CurrentValue=wheatlaistate.DEF;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF);
					if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF);
					if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF.ValueType)){prc.AddCondition(r5);}

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component SiriusQualityWheatLAI.Strategies, strategy " + this.GetType().Name ); }
					return postConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

					string msg = "Component SiriusQualityWheatLAI.Strategies, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
					throw new Exception(msg, exception);
				}
			}

			/// <summary>
			/// Test to verify the preconditions
			/// </summary>
			public string TestPreConditions(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.FPAW.CurrentValue=wheatlaistate.FPAW;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.isPotentialLAI.CurrentValue=wheatlaistate.isPotentialLAI;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.VPDairCanopy.CurrentValue=wheatlaistate.VPDairCanopy;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.FPAW);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.FPAW.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.isPotentialLAI);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.isPotentialLAI.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.VPDairCanopy);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.VPDairCanopy.ValueType)){prc.AddCondition(r3);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LowerFPAWexp")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("UpperFPAWexp")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MaxDSF")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LowerFPAWsen")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("UpperFPAWsen")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("UpperVPD")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LowerVPD")));

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component SiriusQualityWheatLAI.Strategies, strategy " + this.GetType().Name ); }
					return preConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

					string msg = "Component SiriusQualityWheatLAI.Strategies, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
					throw new Exception(msg, exception);
				}
			}

		
	#endregion
		


	#region Model

		 	/// <summary>
			/// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
			/// </summary>
			public void Estimate(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1,CRA.AgroManagement.ActEvents actevents)
			{
				try
				{
					CalculateModel(wheatlaistate,wheatleafstate,wheatleafstate1,actevents);

					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

					string msg = "Error in component SiriusQualityWheatLAI.Strategies, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;				
					throw new Exception(msg, exception);
				}
			}

		

			private void CalculateModel(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1,CRA.AgroManagement.ActEvents actevents)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
				//Code written below will not be overwritten by a future code generation
                if (wheatlaistate.isPotentialLAI==1)
                {
                    wheatlaistate.DEF = 1;
                    wheatlaistate.DSF = 1;
                }
                else
                {

                    wheatlaistate.DEF = CalculateDF(LowerFPAWexp, UpperFPAWexp, 0, 1, wheatlaistate.FPAW, wheatlaistate.VPDairCanopy);
                    wheatlaistate.DSF = CalculateDF(LowerFPAWsen, UpperFPAWsen, MaxDSF, 1, wheatlaistate.FPAW, wheatlaistate.VPDairCanopy);
                }
        

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation
            private double CalculateDF(double lowerFPAW, double upperFPAW, double maxDF, double minDF, double FPAW, double VPDairCanopy)
            {
                // VPD choking function
                double vpdSF = (VPDairCanopy - UpperVPD) / (LowerVPD - UpperVPD);
                if (VPDairCanopy < LowerVPD) vpdSF = 1;
                if (VPDairCanopy > UpperVPD) vpdSF = 0;
                // soil moisture choking function
                double pawSF = (FPAW - lowerFPAW) / (upperFPAW - lowerFPAW);
                if (FPAW > upperFPAW) pawSF = 1;
                if (FPAW < lowerFPAW) pawSF = 0;
                return maxDF + (minDF - maxDF) * pawSF * vpdSF;
            }
				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
