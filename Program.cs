﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Begu
{

    internal partial class Program
    {

        //commons
        readonly DiscordSocketClient _client;

        //server
        SocketGuild Kuru = null; //Star Guardians!

        // DiscordSocketClient
        DiscordSocketConfig DCFG = new DiscordSocketConfig
        {
            GatewayIntents =
                GatewayIntents.MessageContent |
                GatewayIntents.AllUnprivileged &
                ~GatewayIntents.GuildScheduledEvents &
                ~GatewayIntents.GuildInvites
        };

        private Task Updater { get; set; }
        bool onlyOne = false;

        //main
        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
        public Program()
        {

            _client = new DiscordSocketClient(DCFG);
            
            /********************
                Event Handlers
            *////////////////////
            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
            _client.SlashCommandExecuted += SlashCommandHandlerAsync;

        }


    }

}