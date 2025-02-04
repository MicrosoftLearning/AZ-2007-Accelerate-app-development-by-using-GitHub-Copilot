import asyncio
import aiohttp
import tkinter as tk
from tkinter import scrolledtext

class AsyncWebFetcherApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Async Web Fetcher")

        self.start_button = tk.Button(root, text="Start", command=self.on_start_button_click)
        self.start_button.pack()

        self.results_textbox = scrolledtext.ScrolledText(root, width=80, height=20)
        self.results_textbox.pack()

        self.url_list = [
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/xamarin",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/gaming"
        ]

    def on_start_button_click(self):
        self.start_button.config(state=tk.DISABLED)
        self.results_textbox.delete(1.0, tk.END)
        asyncio.run(self.start_sum_page_sizes())

    async def start_sum_page_sizes(self):
        async with aiohttp.ClientSession() as session:
            total_size = 0
            tasks = [self.process_url(url, session) for url in self.url_list]
            results = await asyncio.gather(*tasks)
            for url, size in results:
                self.results_textbox.insert(tk.END, f"{url}: {size} bytes\n")
                total_size += size
            self.results_textbox.insert(tk.END, f"\nTotal size: {total_size} bytes\n")
        self.start_button.config(state=tk.NORMAL)

    async def process_url(self, url, session):
        async with session.get(url) as response:
            content = await response.read()
            return url, len(content)

if __name__ == "__main__":
    root = tk.Tk()
    app = AsyncWebFetcherApp(root)
    root.mainloop() 