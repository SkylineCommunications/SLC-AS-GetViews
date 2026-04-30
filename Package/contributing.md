---
uid: contributing-docs
---

# Contributing to the project documentation

You can contribute to this documentation in the same way as you contribute to docs.dataminer.services. See [Contributing to the DataMiner docs](https://docs.dataminer.services/CONTRIBUTING.html).

> [!NOTE]
> Since the switch to DocFX 2.60 and higher, creating a test build is different for docs and for internaldocs. See [Creating a test build](#creating-a-test-build).

## Creating a test build

1. Make sure [DocFX is correctly installed](https://docs.dataminer.services/CONTRIBUTING.html#installing-and-configuring-docfx).

> [!NOTE]
> Use the information on the referenced page only to install DocFX. For the test build, continue with the steps below.

1. If no Terminal pane is open in Visual Studio Code, go to *Terminal > New Terminal*.

1. In the Terminal pane, do the following:

   1. Enter `clear` to clear the terminal.

   1. Enter `docfx build` to make a test build.

   1. Enter `docfx serve _site` to make this test build available through a local webserver.

   1. In a browser, go to <http://localhost:8080/> to preview the website.

      > [!TIP]
      > If you are not able to access localhost:8080, you can specify a different port by entering e.g. `docfx serve _site -p 8090`.

      When you have finished previewing the website, in the Terminal pane, press ENTER to exit the preview mode.
