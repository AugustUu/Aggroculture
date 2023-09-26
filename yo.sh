#!/bin/sh
echo -ne '\033c\033]0;Aggroculture\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/yo.x86_64" "$@"
