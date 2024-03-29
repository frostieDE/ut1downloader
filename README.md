# UT1Downloader

This tool downloads parts of the UT1 blocklist and transforms them into either the
host or adblock-plus format in order to use those blocklists with Pi-Hole.

## Usage

### Download and transform lists
```bash
$ ut1downloader -o /opt/ut1 -c adult,porn,gambling -s abp
```

It only uses the `domains` file from the given categories. URLs and regexps are not supported,
because it is not supported by Pi-Hole.

In case you only want to block top-level domains, you may use `-s host` instead of `-s abp` as the
former will use the `host`-output style.

AdBlock Plus-style:

```
||example.com^
```

Host-style:

```
0.0.0.0 example.com
```

Lists are downloaded from `https://dsi.ut-capitole.fr/blacklists/download/<category>.tar.gz`. See
[https://dsi.ut-capitole.fr/blacklists/index_en.php](https://dsi.ut-capitole.fr/blacklists/index_en.php) for
 a complete list of categories.

### Add them in Pi-Hole

Just prefix the download path with `file://` and you are good to go. Based on the example above,
you may enter `file:////opt/ut1/adult.txt`

### Updating the lists

You may use tools like crontab oder systemd timers to update the lists on a regular basis. 

## FAQ

### Why not providing ready-to-use lists?

Some of the lists (e.g. adult or porn) are quite large. GitHub only supports files up to 50 MB
when inside a traditional Git repository. Some lists exceed this limit.

### Then why not use Git LFS?

Great idea, but I am not familiar with Git LFS. Thus, I am not able to provide transformed lists
to GitHub. Feel free to help me with this 😊 But we have to respect the original license of the
blocklists.

### Your Azure Pipeline is a mess. Can I fix it?

Very much so 🤣 I am not an expert on this, but it works fine for now.

## Disclaimer

I am not related to the [UT1 Blocklist project](https://dsi.ut-capitole.fr/blacklists/index_en.php).