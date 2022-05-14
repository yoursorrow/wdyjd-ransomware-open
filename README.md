<WHATDIDYOUJUSTDO?>

WDYJD is an open-source C# ransomware project exposing zero-days in W10 as I find them. This source code is readily available to be modified.

Most of this WILL NOT WORK ON W11.

# Usage

I will be publishing the code that sends files to a server sometime in the near future.

You will setup a VPS that hosts files transferred by the malware instantly.

# Obfuscation?

Obfuscation will be merged in the future, don't really wanna leak my C# obfuscation methods just yet until I improve it.

# Features

- Sandbox self-escape (Tested on Avast!)
- Auto-rehash
- Auto-rename
- USB Payloading (soon to be merged into this project)
- VPN detecting
- Self destruct
- Startup lock
- Monitor blackout
- Keyboard Lock
- Mouse Lock
- VM Detection
and many more to come.


  
  
#coding style
  -everything is neat, and in its own function which keeps the _Load to a minimum
  -adding functions is easy, and reading the hooks and callbacks is easy.
  
  -please commit and fork to your heart's content.
  

-sincerely
-yoursorrow
