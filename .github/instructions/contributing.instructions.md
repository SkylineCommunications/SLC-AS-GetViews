---
description: "Use when making changes to this repository: creating pull requests, updating documentation, writing changelogs, or modifying README files. Covers PR workflow, readme maintenance, and DataMiner Catalog documentation best practices."
---
# Contributing Guidelines

## Pull Requests

- Always deliver changes via a pull request — never push directly to `main`.
- Use the pull request template located at `.github/PULL_REQUEST_TEMPLATE/pull_request_template.md`. Fill in all sections:
  - **Why**: Explain the problem solved or value added.
  - **Changes**: High-level summary of what changed, including the most impactful modifications as a concise list.
  - **References**: Link relevant issues or tasks.
  - **Checklist**: Mark each item as applicable.
  - **Reviewer Notes**: Add anything that is non-obvious or that reviewers should pay special attention to.

## README Files

- Keep the **root `README.md`** and the **`SLC-AS-GetViews/README.md`** up to date whenever functionality, usage, or project structure changes.
- Update project overview, usage instructions, and any listed features to reflect the current state of the code.

## Catalog README (`Package/CatalogInformation/README.md`)

Update this file whenever there is an impactful functional change that users deploying from the DataMiner Catalog would care about (new features, removed capabilities, changed prerequisites, etc.).

Follow the [DataMiner best practices for documenting Catalog items](https://docs.dataminer.services/develop/best_practices/Catalog_Items/Best_Practices_When_Documenting_Catalog_Items.html) when editing this file:

### Structure
Use this section order (combine or omit sections for simple items):
1. **About** — Summarize the item's value and the problems it solves. Keep it short, professional, and benefit-oriented. Avoid technical jargon and generic DataMiner features.
2. **Key Features** — At most 5 features. Use action verbs (e.g., "Monitor", "Track"). Focus on what differentiates this item; omit generic DataMiner benefits.
3. **Use Cases** *(optional)* — Real-world, user-centric scenarios. Avoid hypothetical examples. Do not duplicate Key Features content.
4. **Prerequisites** *(optional)* — Concise bullet points. Include minimum DataMiner version (both Feature Release and Main Release tracks), required licenses, DxM versions, or other Catalog items. Do not document complex setup steps — link to documentation instead.
5. **Technical Reference** *(optional)* — Link to detailed external documentation rather than duplicating it inline.

### Visuals
- Include up to 3 visuals to support key points; place images in `Package/CatalogInformation/Images/`.
- Use high-quality, focused screenshots; hide irrelevant columns/panels.
- Keep GIFs concise (max 10 seconds); allow sufficient pause between interactions.
- Never show confidential data — blur sensitive content.

### Writing Style
- Use bold text to highlight important points, but sparingly — overuse dilutes impact.
- Use [DataMiner alert syntax](https://docs.dataminer.services/contributing/CTB_Markdown_Syntax.html#alerts) (`> [!NOTE]`, `> [!TIP]`, etc.) where appropriate, but not excessively.
- Organize content from broad benefits to specific features.
- Do not refer to support or contact details in the description; users should reach out via the DataMiner Support team.
- Link to external documentation (e.g., `docs.dataminer.services`) instead of embedding extensive technical details.
