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
			try
			{
				// Get and validate RootView parameter
				string rootViewString = engine.GetScriptParam("RootView")?.Value;
				if (string.IsNullOrWhiteSpace(rootViewString))
				{
					engine.ExitFail("RootView parameter is required. Please provide a view name or ID.");
					return;
				}

				// Get RootViewInputType parameter with default
				string inputType = engine.GetScriptParam("RootViewInputType")?.Value ?? "Name";

				// Get RecursionLevel parameter with safe handling
				var recursionLevelParam = engine.GetScriptParam("RecursionLevel");
				string recursionLevelString = recursionLevelParam != null ? recursionLevelParam.Value : string.Empty;

				// Parse recursion level, default to 1 if not specified or invalid
				if (!int.TryParse(recursionLevelString, out int recursionLevel) || recursionLevel < 1)
				{
					recursionLevel = 1;
				}

				IDms thisDms = engine.GetDms();

				// Get the root view based on input type
				IDmsView rootView;
				if (string.Equals(inputType, "ID", StringComparison.OrdinalIgnoreCase))
				{
					// Parse the input as an integer ID
					if (!int.TryParse(rootViewString, out int viewId))
					{
						engine.ExitFail($"Invalid View ID: '{rootViewString}'. Please provide a numeric ID (e.g., 123).");
						return;
					}

					rootView = thisDms.GetView(viewId);
				}
				else
				{
					// Default to treating input as a Name
					rootView = thisDms.GetView(rootViewString);
				}

				// Process child views with the specified recursion level
				ProcessViews(engine, rootView.ChildViews, recursionLevel, 1);
			}
			catch (Exception ex)
			{
				engine.ExitFail($"Failed to retrieve view: {ex.Message}. Please verify the view name/ID exists and try again.");
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