"""
Merge editorconfig_ru.editorconfig into .editorconfig.
Comments that describe a rule (comment line immediately above the rule)
are moved to the same line as the rule (trailing comment), matching the
style already used in .editorconfig. Order, duplicates and sections are
preserved verbatim.
"""

SRC = "editorconfig_ru.editorconfig"
DST = ".editorconfig"
with open(SRC, encoding="utf-8") as f:
    src_lines = f.read().splitlines()
# --- Parse into entries -------------------------------------------------
entries = []  # ('comment', text) | ('blank',) | ('section', text) | ('rule', text, comment|None)
for raw in src_lines:
    line = raw.rstrip()
    stripped = line.strip()
    if not stripped:
        entries.append(["blank"])
    elif stripped.startswith("#"):
        entries.append(["comment", line])
    elif stripped.startswith("["):
        entries.append(["section", line])
    else:
        entries.append(["rule", line, None])
# --- Attach the immediately-preceding comment to each rule ---------------
for i, e in enumerate(entries):
    if e[0] == "rule" and i > 0 and entries[i - 1][0] == "comment":
        e[2] = entries[i - 1][1]
        entries[i - 1] = ("consumed",)
# --- Drop leading blank lines -------------------------------------------
while entries and entries[0] == ("blank",):
    entries.pop(0)


# --- Render with per-block comment alignment -----------------------------
def render(entries):
    out = []
    block = []  # consecutive rule entries

    def flush():
        if not block:
            return
        width = max(len(r) for r, _ in block)
        for rule, comment in block:
            if comment:
                out.append(rule.ljust(width + 2) + comment)
            else:
                out.append(rule)
        block.clear()

    for e in entries:
        if e[0] == "rule":
            block.append((e[1], e[2]))
        else:
            flush()
            if e[0] == "comment":
                out.append(e[1])
            elif e[0] == "section":
                out.append("")
                out.append(e[1])
            else:  # blank
                out.append("")
    flush()
    return out


rendered = render(entries)
# --- Build final document ------------------------------------------------
header = [
    "",
    "# ============================================================================",
    "# СТИЛЬ .NET: ГЛОБАЛЬНЫЕ ПРАВИЛА БЕЗ СЕКЦИИ (ПРИМЕНЯЮТСЯ КО ВСЕМ ФАЙЛАМ)",
    "# ============================================================================",
    "[*]",
]
body = [""] + header + rendered
# Collapse 3+ consecutive blank lines into one
final = []
prev_blank = False
for line in body:
    blank = line.strip() == ""
    if blank and prev_blank:
        continue
    final.append(line)
    prev_blank = blank
# Trim trailing blank lines, ensure single trailing newline
while final and final[-1].strip() == "":
    final.pop()
with open(DST, "a", encoding="utf-8") as f:
    f.write("\n".join(final))
print(f"Merged {len(rendered)} lines into {DST}")
