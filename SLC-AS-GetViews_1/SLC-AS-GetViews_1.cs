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
			string rootViewString = engine.GetScriptParam("RootView").Value;

			IDms thisDms = engine.GetDms();
			var views = thisDms.GetViews();

			var rootview = views.FirstOrDefault(x => x.Name == rootViewString);

			var viewsResult = GetViews(views, rootview);

			foreach (var view in viewsResult)
			{
				engine.GenerateInformation($"View: {view.Name} ({view.Id})");
			}
		}

		private IEnumerable<IDmsView> GetViews(IEnumerable<IDmsView> views, IDmsView rootView)
		{
			if (rootView == null)
			{
				return views;
			}

			List<IDmsView> viewList = new List<IDmsView>();
			foreach (var view in views)
			{
				if (view.Parent != null && view.Parent.Id == rootView.Id)
				{
					viewList.Add(view);
				}
			}

			return viewList;
		}
	}
}