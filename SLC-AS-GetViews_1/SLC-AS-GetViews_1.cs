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
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			try
			{
				string rootViewString = engine.GetScriptParam("RootView")?.Value;
				if (string.IsNullOrWhiteSpace(rootViewString))
				{
					engine.ExitFail("RootView parameter is required. Please provide a view name or ID.");
					return;
				}

				string inputType = engine.GetScriptParam("RootViewInputType")?.Value ?? "Name";

				IDms thisDms = engine.GetDms();

				IDmsView views;
				if (string.Equals(inputType, "ID", StringComparison.OrdinalIgnoreCase))
				{
					// Parse the input as an integer ID
					if (!int.TryParse(rootViewString, out int viewId))
					{
						engine.ExitFail($"Invalid View ID: '{rootViewString}'. Please provide a numeric ID (e.g., 123).");
						return;
					}

					views = thisDms.GetView(viewId);
				}
				else
				{
					// Default to treating input as a Name
					views = thisDms.GetView(rootViewString);
				}

				foreach (var view in views.ChildViews)
				{
					engine.GenerateInformation($"View: {view.Name} ({view.Id})");
				}
			}
			catch (Exception ex)
			{
				engine.ExitFail($"Failed to retrieve view: {ex.Message}. Please verify the view name/ID exists and try again.");
			}
		}
	}
}