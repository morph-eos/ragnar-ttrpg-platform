# Contributing

The Ragnar TTRPG Platform is an **archived portfolio project**. It is preserved
to document the engineering evolution of the platform across three application
rewrites and two infrastructure projects — it is not under active development.

## Repository layout

This is a unified monorepo. Each top-level directory is a self-contained
sub-project that was merged in **with its complete original commit history**:

| Directory | Phase | Stack |
|-----------|-------|-------|
| `hp-main/` | Legacy | React 18 + Express + MongoDB (MERN) |
| `hp-jh-transition/` | Transition | Angular 17 + Spring Boot 3.2 + PostgreSQL |
| `jh-main/` | Modern | Angular 18 + .NET 8 + PostgreSQL |
| `jh-devops/` | Infra | GitHub Actions, Azure VM, Terraform |
| `jh-cloud/` | Infra | Docker Compose, Nextcloud, Nginx |

Build and run instructions live in each sub-project's own `README.md`.

## History conventions

- Every sub-project's history is reachable from `main` and path-scoped, so
  `git log -- <subdir>/` shows that project's real history.
- Author identities are normalized through [`.mailmap`](.mailmap). If you commit
  under a new identity, add a mapping there rather than leaving it split.
- Phase milestones are marked with annotated tags: `v1-legacy`,
  `v2-transition`, `v3-modern`.

## Pull requests

Because the project is archived, only documentation and history-hygiene fixes
are expected. Keep commit messages descriptive and imperative
(e.g. `Fix broken demo link in jh-main README`), and avoid amending or
force-pushing the preserved sub-project history.

## License

Contributions are accepted under the project's
[CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/) license.
