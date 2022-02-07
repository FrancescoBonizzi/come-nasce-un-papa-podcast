﻿using Microsoft.AspNetCore.StaticFiles;

namespace WebSite.HttpLifecycle
{
    public static class CustomMiddlewares
    {
        public static FileExtensionContentTypeProvider GenerateStaticFilesContentProvider()
        {
            var provider = new FileExtensionContentTypeProvider();

            // Queste definizioni sono più corrette di quelle di default, secondo Mozilla
            provider.Mappings[".css"] = "text/css; charset=utf-8";
            provider.Mappings[".js"] = "text/javascript; charset=utf-8";
            provider.Mappings[".ttf"] = "font/ttf";
            provider.Mappings[".ico"] = "image/x-icon";
            provider.Mappings[".svg"] = "image/svg+xml";
            provider.Mappings[".ttf"] = "application/x-font-ttf";
            provider.Mappings[".woff"] = "application/x-font-woff";
            provider.Mappings[".eot"] = "application/vnd.ms-fontobject";
            provider.Mappings[".mp3"] = "audio/mpeg";

            return provider;
        }
    }
}
