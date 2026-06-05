---
uid: overview
---

# Overview

The **SLC-AS-GetViews** script is a DataMiner Automation script that retrieves and displays the hierarchical structure of views within a DataMiner System (DMS). Starting from a specified root view, it traverses the child view hierarchy and logs each view's name and ID with indentation that visually reflects the depth of each view in the tree.

This script is intended for **DataMiner administrators and engineers** who need a quick, structured snapshot of how views are organized in their system.

## Key Features

| Feature | Description |
|---|---|
| **Flexible input** | Accept a root view by either its **name** or its **ID**, controlled by the `RootViewInputType` parameter. |
| **Configurable depth** | Control how many levels deep the traversal goes with the `RecursionLevel` parameter. Default is `1` (direct children only). |
| **Indented output** | Each view is logged with indentation proportional to its depth, making the hierarchy immediately readable in the DataMiner log output. |
| **Comprehensive info** | Each logged line includes both the view **name** and its numeric **ID** for unambiguous identification. |

## Input Parameters at a Glance

| Parameter | Type | Default | Description |
|---|---|---|---|
| `RootView` | Text | *(required)* | The name or ID of the view to start from. |
| `RootViewInputType` | Choice | `Name` | Whether `RootView` is interpreted as a `Name` or an `ID`. |
| `RecursionLevel` | Number | `1` | How many levels of child views to traverse. |

## Use Cases

### View Structure Auditing

When managing a large DMS with a complex view hierarchy, you can use this script to quickly generate a map of any branch of the view tree — making it easy to spot structural inconsistencies or document the current state.

### Documentation and Reporting

The indented log output can be copied directly into system architecture documentation or handed over during system transitions. Combined with the `RecursionLevel` parameter, you can scope the output to exactly the depth you need.

### Troubleshooting

When debugging Automation scripts that reference specific views by name or ID, this script lets you quickly verify that a given view exists, confirm its exact ID, and inspect its children without navigating through the DataMiner Cube UI.
