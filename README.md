# SLC-AS-GetViews

This script will ask for two script parameters:

- RootView: Name of the view for which the subviews will be returned.
- RecursionLevel: The level of recursion for retrieving subviews (number). Specifying '1' shows direct subviews, '2' goes one level deeper, etc. Defaults to 1 if not specified or invalid.

## Logic

The script will log in information events a list of views that are under the specified root view, up to the specified recursion level. The name and ID of each view are logged with indentation to show the hierarchy level.

## Future Implementation Ideas

Go to the 'Issues' tab to find out the limitations and future enhancements of this script.
