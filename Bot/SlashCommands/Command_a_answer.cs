﻿using Discord.WebSocket;
using Discord;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Begu
{
    internal partial class Program
    {
        private async Task Command_a_answer(SocketSlashCommand command)
        {
            await command.DeferAsync(ephemeral: true);

            string cnls = "";

            if (Properties.Settings.Default.TalkChannel == null)
            { Properties.Settings.Default.TalkChannel = new StringCollection(); }

            //setting texts
            if (Properties.Settings.Default.TalkChannel.Count != 0)
            {

                foreach (string item in Properties.Settings.Default.TalkChannel)
                {
                    var t = Kuru.GetTextChannel(ulong.Parse(item));
                    cnls += t.Mention;

                    if (item == Properties.Settings.Default.TalkChannel[Properties.Settings.Default.TalkChannel.Count - 1])
                    {
                        cnls += ".";
                    }
                    else
                    {
                        cnls += ", ";
                    }
                }
            }
            else
            {
                cnls = "No channel, use `/talkc` for set.";
            }


            string logc1 = $"Current log channel/s: {((Properties.Settings.Default.LogChannel == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}";
            string logc2 = (Properties.Settings.Default.LogChannel == 0) ? "No channel, use `/logc` for set." : (Kuru.GetTextChannel(Properties.Settings.Default.LogChannel)).Mention;

            string newsc1 = $"Current ff news channel: {((Properties.Settings.Default.news_channel == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}";
            string newsc2 = (Properties.Settings.Default.news_channel == 0) ? "No channel, use `/newsc` for set." : (Kuru.GetTextChannel(Properties.Settings.Default.news_channel)).Mention;

            string updatec1 = $"Current ff update channel: {((Properties.Settings.Default.update_channel == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}";
            string updatec2 = (Properties.Settings.Default.update_channel == 0) ? "No channel, use `/updatec` for set." : (Kuru.GetTextChannel(Properties.Settings.Default.update_channel)).Mention;

            string status1 = $"Current ff status channel: {((Properties.Settings.Default.status_channel == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}";
            string status2 = (Properties.Settings.Default.status_channel == 0) ? "No channel, use `/statusc` for set." : (Kuru.GetTextChannel(Properties.Settings.Default.status_channel)).Mention;

            string maint1 = $"Current ff maintenance channel: {((Properties.Settings.Default.maintenance_channel == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}";
            string maint2 = (Properties.Settings.Default.maintenance_channel == 0) ? "No channel, use `/maintenancec` for set." : (Kuru.GetTextChannel(Properties.Settings.Default.maintenance_channel)).Mention;

            //embed
            var admin_embc = new EmbedBuilder()
            .WithTitle($"Admin settings status.")
            .WithDescription(Emote.Bot.Sproud + " Because you looks lost. " + Emote.Bot.Sproud)
            .WithColor(Color.Orange)
            .AddField($"Current answer channel/s: {((Properties.Settings.Default.TalkChannel.Count == 0) ? Emote.XD.RedCircle : Emote.XD.GeenCircle)}", cnls, false)
            .AddField(logc1, logc2, false)
            .AddField(newsc1, newsc2, false)
            .AddField(updatec1, updatec2, false)
            .AddField(status1, status2, false)
            .AddField(maint1, maint2, false)
            .WithFooter("Take care.")
            .WithTimestamp(DateTimeOffset.Now)
            .Build();
            var m = await command.FollowupAsync("", embed: admin_embc, ephemeral: true);
            BorrarMsg(m, 20);

        }
    }
}
