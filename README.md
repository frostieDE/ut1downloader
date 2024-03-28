# UT1Downloader

This tool downloads parts of the UT1 blocklist and transforms them into either the
host or adblock-plus format in order to use those blocklists with Pi-Hole.

## Usage

```bash
$ ut1downloader -o /opt/ut1 -c adult,porn,gambling
```

It only uses the `domains` file from the given categories. URLs and regexps are not supported,
because it is not supported by Pi-Hole.

## FAQ

### Why not providing ready-to-use lists?

Some of the lists (e.g. adult or porn) are quite large. GitHub only supports files up to 50 MB
when inside a traditional Git repository. Some lists exceed this limit.

### Then why not use Git LFS?

Great idea, but I am not familiar with Git LFS. Thus, I am not able to provide transformed lists
to GitHub. Feel free to help me with this 😊