# Git Stylguide

## Commit Messages
1. Use **Present Tense** ("Add feature" not "Added feature")
2. Use the **Imperative Mood** ("Move cursor to..." not "Moves cursor to...")
3. Use the *Message body* only if you **have to** provide extra details
4. Keep each commit message short and precise
5. Commits should encompass a *logical* change
6. Preface each commit with the applicable **emoji** (see below)

| Emoji | Raw Emoji Code | Description |
|:---:|:---:|---|
| :art: | `:art:` | when improving the **format**/structure of the code |
| :pencil: | `:pencil:` | when **performing minor changes/fixing** the code or language |
| :racehorse: | `:racehorse:` | when improving **performance** |
| :books: | `:books:` | when writing **docs** |
| :bug: | `:bug:` | when fixing a bug |
| :fire: | `:fire:` | when **removing** code or files |
| :tractor: | `:tractor:` | when **change file structure** |
| :umbrella: | `:umbrella:` | when adding **tests** |
| :lock: | `:lock:` | when dealing with **security** |
| :arrow_up: | `:arrow_up:` | when upgrading **dependencies** |
| :arrow_down: | `:arrow_down:` | when downgrading **dependencies** |
| :lipstick: | `:lipstick:` | when improving **UI**/Cosmetic (in this case e.g. language outputs) |
| :globe_with_meridians: | `:globe_with_meridians:` | when dealing with **globalization**/internationalization/i18n/g11n |
| :construction: | `:construction:` | **WIP**(Work In Progress) Commits, _maybe_ with `@REVIEW` Comment Tag |
| :speaker: | `:speaker:` | when Adding **Logging** |
| :mute: | `:mute:` | when Reducing **Logging** |
| :sparkles: | `:sparkles:` | when introducing **New** Features |
| :rocket: | `:rocket:` | Anything related to Deployments/**DevOps** |

## Branches

### Naming convention
Prefix your branch name with an applicable prefix and try to keep branch names as short as possible.
| Prefix | Purpose |
|:---: | :---: |
| feature/ | **adding** a feature |
| bug/ |**fixing** a bug |
| doc/ | **changing or adding** documentation |

**Examples**
```
feature/add-cool-new-feature
bug/fix-Alexa-ending-conversation
```

### Rebasing
Make sure to rebase your branches regularly. Especially before opening a Pull Request.

## Pull Requests
Each Pull Request should have a **short and descriptive title**.

Use the **body** of the Pull Request to add vital information pertaining that request. This information should include (but is not limited to):

1. Changes this PR introduces
2. Reasoning behind the changes

## Reviewing
Every Pull Request should be reviewed by **at least 2 team members** before it is merged into the master.

Make sure to review as many Pull Requests as you can. This will not only help others improve, but will also help you improve!

Reviews should be short and simple. Keep reviews in a positive tone and open for discussions.

Do not give a general "This is bad" but instead comment on the lines of code that need improvement or, if the Pull Request as a whole needs changes, explain what you think needs to be done. 

```
Remember: You want constructive criticism when sending in your Pull Request aswell. So keep it civil!
```