---
uid: glossary
---

# Glossary

Definitions for terms used throughout this documentation.

---

### Child View

A view that is directly nested inside another view (its *parent*). A child view can itself have further child views, forming a tree structure.

---

### DataMiner Automation Script

A piece of C# code hosted and executed by the DataMiner platform. Scripts can be triggered manually, on a schedule, by an alarm, or by another script. **SLC-AS-GetViews** is a DataMiner Automation script.

---

### DIS (DataMiner Integration Studio)

A Visual Studio extension developed by Skyline Communications. DIS allows developers to author, debug, and deploy DataMiner Automation scripts, connectors, and other artifacts directly from Visual Studio. It also enables connecting to a live DataMiner Agent for import and testing.

---

### DMS (DataMiner System)

A DataMiner System is the full deployment of one or more DataMiner Agents, together forming the monitoring and orchestration platform.

---

### `ExitFail`

An `IEngine` method (`engine.ExitFail(message)`) that terminates an Automation script and marks it as *failed* in the DataMiner platform, making the failure visible in logs, correlated alarms, and dependent workflows.

---

### `IDms`

The `IDms` interface from `Skyline.DataMiner.Core.DataMinerSystem.Common`. It represents the DataMiner System and provides access to its elements, views, and services in a strongly typed, testable way.

---

### `IEngine`

The `IEngine` interface provided by the DataMiner Automation framework. It is the primary entry point for script execution, giving access to script parameters, logging, and script lifecycle control (`ExitFail`, `ExitSuccess`).

---

### Recursion Level

The `RecursionLevel` script parameter. A value of `1` returns only the direct children of the root view. Each increment adds one more level of depth to the traversal.

---

### Root View

The view specified by the `RootView` parameter. It serves as the starting point of the traversal; the script lists the children of this view (and their children, up to the configured depth), but does not log the root view itself.

---

### View

A DataMiner object used to organize elements and services into a logical hierarchy, similar to a folder. Views can be nested inside other views to represent organizational structures such as locations, departments, or technology domains.
