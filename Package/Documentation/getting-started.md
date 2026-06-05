---
uid: getting-started
---

# Getting Started

This page walks you through everything you need to run the **SLC-AS-GetViews** script for the first time.

## Prerequisites

- Access to a **DataMiner System (DMS)** with at least one view configured.
- The script deployed to your DMS (via the DataMiner Catalog or manually through DIS).
- **DataMiner Cube** to execute the script and read its output, or a DataMiner Automation trigger.

## Running the Script

1. Open **DataMiner Cube** and navigate to *Apps* > *Automation*.
2. Find the script named **SLC-AS-GetViews** in the script list.
3. Click **Execute** to open the parameter dialog.
4. Fill in the input parameters (see below).
5. Click **Execute now**.
6. Open the *Information Events* pane or the Automation script log to view the output.

## Input Parameters

### RootView

- **Type**: Text (string)
- **Required**: Yes
- **Description**: The starting point of the view traversal. Provide either the view's display name or its numeric ID, depending on what you set for `RootViewInputType`.

**Examples:**

| `RootViewInputType` | `RootView` value | Result |
|---|---|---|
| `Name` | `My Network` | Resolves the view named *My Network* |
| `ID` | `123` | Resolves the view with ID *123* |

---

### RootViewInputType

- **Type**: Multiple choice
- **Default**: `Name`
- **Options**: `Name`, `ID`
- **Description**: Tells the script how to interpret the `RootView` parameter.

> [!NOTE]
> If you set `RootViewInputType` to `ID` but provide a non-numeric value, the script will exit with an error. If you set it to `Name` but provide a numeric string, the script searches for a view whose *name* matches that string — not its ID.

---

### RecursionLevel

- **Type**: Number (parsed as integer)
- **Default**: `1`
- **Description**: Controls how many levels of child views are traversed. A value of `1` returns only the direct children of the root view. A value of `2` also returns their children, and so on.

> [!TIP]
> Start with the default of `1` on large systems. Deep recursion on a root view with many descendants can produce a large volume of log entries.

## Example Output

Given a view *Operations* with ID `10` containing child views *Site A* (ID `11`) and *Site B* (ID `12`), each with one child view, running with `RecursionLevel = 2` produces:

```
View: Site A (11)
  View: Floor 1 (21)
View: Site B (12)
  View: Floor 1 (22)
```

Each level of indentation represents one additional depth level (2 spaces per level).

## Known Error Messages

| Message | Cause |
|---|---|
| `RootView parameter is required.` | The `RootView` parameter was left empty. |
| `Invalid View ID: '...'. Please provide a numeric ID.` | `RootViewInputType` is `ID` but the value is not a valid integer. |
| `Failed to retrieve view: ... Please verify the view name/ID exists.` | No view matching the given name or ID was found in the DMS. |
