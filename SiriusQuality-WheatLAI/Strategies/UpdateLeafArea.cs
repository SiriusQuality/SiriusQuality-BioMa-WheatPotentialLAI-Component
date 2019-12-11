

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:10/4/2018
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
	///Class UpdateLeafArea
    /// Increase or Decrease (senescing leaves) the lamina and sheath Area Index
    /// </summary>
	public class UpdateLeafArea : IStrategySiriusQualityWheatLAI
	{

	#region Constructor

			public UpdateLeafArea()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 1.98;
				 v1.Description = "Critical area-based nitrogen content for leaf expansion";
				 v1.Id = 0;
				 v1.MaxValue = 100;
				 v1.MinValue = 0;
				 v1.Name = "SLNcri";
				 v1.Size = 1;
				 v1.Units = "g(N)/m²(leaf)";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 1.1;
				 v2.Description = "Phyllochronic duration of leaf lamina expansion";
				 v2.Id = 0;
				 v2.MaxValue = 100;
				 v2.MinValue = 0;
				 v2.Name = "PexpL";
				 v2.Size = 1;
				 v2.Units = "phyllochron";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd1.PropertyName = "cumulTTShoot";
				pd1.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd2.PropertyName = "potentialIncDeltaArea";
				pd2.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd3.PropertyName = "incDeltaAreaLimitSF";
				pd3.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd4.PropertyName = "WaterLimitedPotDeltaAIList";
				pd4.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList);
				_inputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd5.PropertyName = "availableN";
				pd5.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.availableN)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.availableN);
				_inputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd6.PropertyName = "LaminaAI";
				pd6.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
				_inputs0_0.Add(pd6);
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd7.PropertyName = "MaxAI";
				pd7.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
				_inputs0_0.Add(pd7);
				PropertyDescription pd8 = new PropertyDescription();
				pd8.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd8.PropertyName = "State";
				pd8.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State)).ValueType.TypeForCurrentValue;
				pd8.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
				_inputs0_0.Add(pd8);
				PropertyDescription pd9 = new PropertyDescription();
				pd9.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd9.PropertyName = "Phyllochron";
				pd9.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron)).ValueType.TypeForCurrentValue;
				pd9.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron);
				_inputs0_0.Add(pd9);
				PropertyDescription pd10 = new PropertyDescription();
				pd10.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd10.PropertyName = "TTem";
				pd10.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem)).ValueType.TypeForCurrentValue;
				pd10.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem);
				_inputs0_0.Add(pd10);
				PropertyDescription pd11 = new PropertyDescription();
				pd11.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd11.PropertyName = "SheathAI";
				pd11.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI)).ValueType.TypeForCurrentValue;
				pd11.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
				_inputs0_0.Add(pd11);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd12 = new PropertyDescription();
				pd12.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd12.PropertyName = "MaxAI";
				pd12.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI)).ValueType.TypeForCurrentValue;
				pd12.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
				_outputs0_0.Add(pd12);
				PropertyDescription pd13 = new PropertyDescription();
				pd13.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd13.PropertyName = "incDeltaArea";
				pd13.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaArea)).ValueType.TypeForCurrentValue;
				pd13.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaArea);
				_outputs0_0.Add(pd13);
				PropertyDescription pd14 = new PropertyDescription();
				pd14.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd14.PropertyName = "deltaAI";
				pd14.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.deltaAI)).ValueType.TypeForCurrentValue;
				pd14.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.deltaAI);
				_outputs0_0.Add(pd14);
				PropertyDescription pd15 = new PropertyDescription();
				pd15.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd15.PropertyName = "GAI";
				pd15.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI)).ValueType.TypeForCurrentValue;
				pd15.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI);
				_outputs0_0.Add(pd15);
				PropertyDescription pd16 = new PropertyDescription();
				pd16.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd16.PropertyName = "LaminaAI";
				pd16.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI)).ValueType.TypeForCurrentValue;
				pd16.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
				_outputs0_0.Add(pd16);
				PropertyDescription pd17 = new PropertyDescription();
				pd17.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd17.PropertyName = "SheathAI";
				pd17.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI)).ValueType.TypeForCurrentValue;
				pd17.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
				_outputs0_0.Add(pd17);
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
				get { return "Increase or Decrease (senescing leaves) the lamina and sheath Area Index"; }
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
				_pd.Add("Creator", "loic.manceau@inra.fr");
				_pd.Add("Date", "10/4/2018");
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

			
			public Double SLNcri
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("SLNcri");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'SLNcri' not found (or found null) in strategy 'UpdateLeafArea'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("SLNcri");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'SLNcri' not found in strategy 'UpdateLeafArea'");
				}
			}
			public Double PexpL
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("PexpL");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'PexpL' not found (or found null) in strategy 'UpdateLeafArea'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("PexpL");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'PexpL' not found in strategy 'UpdateLeafArea'");
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
                SLNcriVarInfo.Name = "SLNcri";
				SLNcriVarInfo.Description =" Critical area-based nitrogen content for leaf expansion";
				SLNcriVarInfo.MaxValue = 100;
				SLNcriVarInfo.MinValue = 0;
				SLNcriVarInfo.DefaultValue = 1.98;
				SLNcriVarInfo.Units = "g(N)/m²(leaf)";
				SLNcriVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				PexpLVarInfo.Name = "PexpL";
				PexpLVarInfo.Description =" Phyllochronic duration of leaf lamina expansion";
				PexpLVarInfo.MaxValue = 100;
				PexpLVarInfo.MinValue = 0;
				PexpLVarInfo.DefaultValue = 1.1;
				PexpLVarInfo.Units = "phyllochron";
				PexpLVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _SLNcriVarInfo= new VarInfo();
				/// <summary> 
				///SLNcri VarInfo definition
				/// </summary>
				public static VarInfo SLNcriVarInfo
				{
					get { return _SLNcriVarInfo; }
				}
				private static VarInfo _PexpLVarInfo= new VarInfo();
				/// <summary> 
				///PexpL VarInfo definition
				/// </summary>
				public static VarInfo PexpLVarInfo
				{
					get { return _PexpLVarInfo; }
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
					
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.CurrentValue=wheatleafstate.MaxAI;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaArea.CurrentValue=wheatlaistate.incDeltaArea;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.deltaAI.CurrentValue=wheatleafstate.deltaAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI.CurrentValue=wheatleafstate.GAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.CurrentValue=wheatleafstate.LaminaAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.CurrentValue=wheatleafstate.SheathAI;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
					if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.ValueType)){prc.AddCondition(r12);}
					RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaArea);
					if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaArea.ValueType)){prc.AddCondition(r13);}
					RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.deltaAI);
					if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.deltaAI.ValueType)){prc.AddCondition(r14);}
					RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI);
					if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI.ValueType)){prc.AddCondition(r15);}
					RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
					if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.ValueType)){prc.AddCondition(r16);}
					RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
					if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.ValueType)){prc.AddCondition(r17);}

					

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
					
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot.CurrentValue=wheatlaistate.cumulTTShoot;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea.CurrentValue=wheatlaistate.potentialIncDeltaArea;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF.CurrentValue=wheatlaistate.incDeltaAreaLimitSF;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList.CurrentValue=wheatlaistate.WaterLimitedPotDeltaAIList;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.availableN.CurrentValue=wheatlaistate.availableN;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.CurrentValue=wheatleafstate.LaminaAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.CurrentValue=wheatleafstate.MaxAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.CurrentValue=wheatleafstate.State;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron.CurrentValue=wheatleafstate.Phyllochron;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem.CurrentValue=wheatleafstate.TTem;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.CurrentValue=wheatleafstate.SheathAI;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList);
					if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.availableN);
					if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.availableN.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
					if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.ValueType)){prc.AddCondition(r6);}
					RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
					if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.ValueType)){prc.AddCondition(r7);}
					RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
					if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.ValueType)){prc.AddCondition(r8);}
					RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron);
					if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron.ValueType)){prc.AddCondition(r9);}
					RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem);
					if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem.ValueType)){prc.AddCondition(r10);}
					RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
					if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.ValueType)){prc.AddCondition(r11);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLNcri")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("PexpL")));

					

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

                if (wheatlaistate.potentialIncDeltaArea > 0.0)
                {

                    if (wheatlaistate.incDeltaAreaLimitSF == 0.0)
                    {
                        wheatlaistate.incDeltaArea = 0;
                    }
                    else
                    {
                        wheatlaistate.incDeltaArea = wheatlaistate.incDeltaAreaLimitSF * Math.Min(1.0, wheatlaistate.availableN / (wheatlaistate.incDeltaAreaLimitSF * SLNcri));
                        IsNumber(wheatlaistate.incDeltaArea);

                    }

                    double stressGrowth = wheatlaistate.incDeltaArea / wheatlaistate.potentialIncDeltaArea;

                    for (int ilayer = 0; ilayer < wheatleafstate.GAI.Count; ilayer++)
                    {
                        if (wheatlaistate.WaterLimitedPotDeltaAIList[ilayer] > 0.0) // leaf layer is growing
                        {
                            IsNumber(stressGrowth);
                            wheatleafstate.deltaAI[ilayer] = wheatlaistate.WaterLimitedPotDeltaAIList[ilayer] * stressGrowth;
                            if ((wheatlaistate.cumulTTShoot - wheatleafstate.TTem[ilayer]) < wheatleafstate.Phyllochron[ilayer] * PexpL)
                            {
                                wheatleafstate1.LaminaAI[ilayer] = wheatleafstate.LaminaAI[ilayer] + wheatleafstate.deltaAI[ilayer];
                                wheatleafstate.LaminaAI[ilayer] = wheatleafstate1.LaminaAI[ilayer];
                            }
                            else
                            {
                                wheatleafstate1.SheathAI[ilayer] = wheatleafstate.SheathAI[ilayer] + wheatleafstate.deltaAI[ilayer];
                                wheatleafstate.SheathAI[ilayer] = wheatleafstate1.SheathAI[ilayer];
                            }

                            wheatleafstate.GAI[ilayer] = wheatleafstate.LaminaAI[ilayer] + wheatleafstate.SheathAI[ilayer];

                            wheatleafstate1.MaxAI[ilayer] = Math.Max(wheatleafstate.MaxAI[ilayer], wheatleafstate.GAI[ilayer]);
                            wheatleafstate.MaxAI[ilayer] = wheatleafstate1.MaxAI[ilayer];
                        }

                    }

                }
                else wheatlaistate.incDeltaArea = 0;

                for (int ilayer = 0; ilayer < wheatleafstate.GAI.Count; ilayer++)
                {
                    if (wheatleafstate.State[ilayer] == 2)
                    {
                        wheatleafstate.deltaAI[ilayer] = wheatlaistate.WaterLimitedPotDeltaAIList[ilayer];
                        double gai = wheatleafstate.GAI[ilayer];
                        if (gai > 0)
                        {
                            var leafLaminaeDec = wheatlaistate.WaterLimitedPotDeltaAIList[ilayer] * wheatleafstate.LaminaAI[ilayer] / gai;
                            var exposedSheathDec = wheatlaistate.WaterLimitedPotDeltaAIList[ilayer] * wheatleafstate.SheathAI[ilayer] / gai;

                            wheatleafstate1.LaminaAI[ilayer] = wheatleafstate.LaminaAI[ilayer] + leafLaminaeDec;
                            wheatleafstate1.SheathAI[ilayer] = wheatleafstate.SheathAI[ilayer] + exposedSheathDec;

                            wheatleafstate.LaminaAI[ilayer] = wheatleafstate1.LaminaAI[ilayer];
                            wheatleafstate.SheathAI[ilayer] = wheatleafstate1.SheathAI[ilayer];
                        }
                    }

                }

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation


              public static void IsNumber(double value)
             {
                // Console.WriteLine("valeur" + value);
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                throw new ArgumentOutOfRangeException("value", "incDeltaArea" + ": is not a number." );
                }
              }

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
