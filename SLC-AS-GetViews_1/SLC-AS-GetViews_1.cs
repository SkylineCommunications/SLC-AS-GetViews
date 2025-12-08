/*
****************************************************************************
*  Copyright (c) 2024,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

16/02/2024	1.0.0.1		JarnoLE, Skyline	Initial version
****************************************************************************
*/

namespace SLC_AS_GetViews_1
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;

	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		private const int IndentationSpaces = 2;

		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			// Get and validate RootView parameter
			string rootViewString = engine.GetScriptParam("RootView").Value;
			if (string.IsNullOrWhiteSpace(rootViewString))
			{
				engine.GenerateInformation("Error: RootView parameter is required and cannot be empty.");
				return;
			}

			// Get RecursionLevel parameter with safe handling
			var recursionLevelParam = engine.GetScriptParam("RecursionLevel");
			string recursionLevelString = recursionLevelParam != null ? recursionLevelParam.Value : string.Empty;

			// Parse recursion level, default to 1 if not specified or invalid
			if (!int.TryParse(recursionLevelString, out int recursionLevel) || recursionLevel < 1)
			{
				recursionLevel = 1;
			}

			try
			{
				IDms thisDms = engine.GetDms();
				var rootView = thisDms.GetView(rootViewString);

				// Process child views with the specified recursion level
				ProcessViews(engine, rootView.ChildViews, recursionLevel, 1);
			}
			catch (Exception ex)
			{
				engine.GenerateInformation($"Error: Unable to retrieve view '{rootViewString}'. Please verify the view name and try again.");
				engine.Log($"Exception details: {ex.Message}");
			}
		}

		/// <summary>
		/// Recursively processes views up to the specified depth level.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		/// <param name="views">Collection of views to process.</param>
		/// <param name="recursionLevel">The recursion level specified by the user (1 = direct children only).</param>
		/// <param name="currentLevel">Current level in the hierarchy (1 = direct children).</param>
		private void ProcessViews(IEngine engine, IEnumerable<IDmsView> views, int recursionLevel, int currentLevel)
		{
			string indentation = new string(' ', (currentLevel - 1) * IndentationSpaces);

			foreach (var view in views)
			{
				engine.GenerateInformation($"{indentation}View: {view.Name} ({view.Id})");

				// Recursively process child views if we haven't reached the max level
				if (currentLevel < recursionLevel)
				{
					ProcessViews(engine, view.ChildViews, recursionLevel, currentLevel + 1);
				}
			}
		}
	}
}