

 //Author:pierre.martre pierre.martre@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:9/28/2017
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
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace SiriusQualityWheatLAI.Strategies
{

	/// <summary>
	///Class SenescenceThermalTime
    /// Calculate Thermal Time at Senescence
    /// </summary>
	public class SenescenceThermalTime : IStrategySiriusQualityWheatLAI
	{

	#region Constructor

			public SenescenceThermalTime()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 2;
				 v1.Description = "Potential phyllochronic duration of the senescence period for the leaves produced after floral initiation";
				 v1.Id = 0;
				 v1.MaxValue = 30;
				 v1.MinValue = 0;
				 v1.Name = "PsenLL";
				 v1.Size = 1;
				 v1.Units = "leaf";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 3.3;
				 v2.Description = "Potential phyllochronic duration of the senescence period for the leaves produced before floral initiation";
				 v2.Id = 0;
				 v2.MaxValue = 30;
				 v2.MinValue = 0;
				 v2.Name = "PsenSL";
				 v2.Size = 1;
				 v2.Units = "leaf";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd1.PropertyName = "Phyllochron";
				pd1.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd2.PropertyName = "index";
				pd2.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.index)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.index);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd3.PropertyName = "isSmallPhytomer";
				pd3.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isSmallPhytomer)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isSmallPhytomer);
				_inputs0_0.Add(pd3);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd4.PropertyName = "TTsen";
				pd4.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen);
				_outputs0_0.Add(pd4);
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
				get { return "Calculate Thermal Time at Senescence"; }
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
				_pd.Add("Date", "9/28/2017");
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

			
			public Double PsenLL
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("PsenLL");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'PsenLL' not found (or found null) in strategy 'SenescenceThermalTime'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("PsenLL");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'PsenLL' not found in strategy 'SenescenceThermalTime'");
				}
			}
			public Double PsenSL
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("PsenSL");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'PsenSL' not found (or found null) in strategy 'SenescenceThermalTime'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("PsenSL");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'PsenSL' not found in strategy 'SenescenceThermalTime'");
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
                PsenLLVarInfo.Name = "PsenLL";
				PsenLLVarInfo.Description =" Potential phyllochronic duration of the senescence period for the leaves produced after floral initiation";
				PsenLLVarInfo.MaxValue = 30;
				PsenLLVarInfo.MinValue = 0;
				PsenLLVarInfo.DefaultValue = 2;
				PsenLLVarInfo.Units = "leaf";
				PsenLLVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				PsenSLVarInfo.Name = "PsenSL";
				PsenSLVarInfo.Description =" Potential phyllochronic duration of the senescence period for the leaves produced before floral initiation";
				PsenSLVarInfo.MaxValue = 30;
				PsenSLVarInfo.MinValue = 0;
				PsenSLVarInfo.DefaultValue = 3.3;
				PsenSLVarInfo.Units = "leaf";
				PsenSLVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _PsenLLVarInfo= new VarInfo();
				/// <summary> 
				///PsenLL VarInfo definition
				/// </summary>
				public static VarInfo PsenLLVarInfo
				{
					get { return _PsenLLVarInfo; }
				}
				private static VarInfo _PsenSLVarInfo= new VarInfo();
				/// <summary> 
				///PsenSL VarInfo definition
				/// </summary>
				public static VarInfo PsenSLVarInfo
				{
					get { return _PsenSLVarInfo; }
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
					
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen.CurrentValue=wheatleafstate.TTsen;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen);
					if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen.ValueType)){prc.AddCondition(r4);}

					

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
					
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron.CurrentValue=wheatleafstate.Phyllochron;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.index.CurrentValue=wheatlaistate.index;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.isSmallPhytomer.CurrentValue=wheatleafstate.isSmallPhytomer;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.Phyllochron.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.index);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.index.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.isSmallPhytomer);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isSmallPhytomer.ValueType)){prc.AddCondition(r3);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("PsenLL")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("PsenSL")));

					

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

                if (wheatleafstate.isSmallPhytomer[wheatlaistate.index] == 0)
                {

                    wheatleafstate.TTsen[wheatlaistate.index] = PsenLL * wheatleafstate.Phyllochron[wheatlaistate.index];
                }
                else
               {
                   wheatleafstate.TTsen[wheatlaistate.index] = PsenSL * wheatleafstate.Phyllochron[wheatlaistate.index];
                }

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
