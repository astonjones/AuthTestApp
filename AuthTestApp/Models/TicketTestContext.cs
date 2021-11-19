using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuthTestApp.Models
{
    public partial class TicketTestContext : DbContext
    {
        public TicketTestContext()
        {
        }

        public TicketTestContext(DbContextOptions<TicketTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hardware> Hardwares { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<VicidialApiLog> VicidialApiLogs { get; set; }
        public virtual DbSet<VicidialCampaign> VicidialCampaigns { get; set; }
        public virtual DbSet<VicidialCarrierLog> VicidialCarrierLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TicketTest;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Hardware>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.ToTable("Hardware");

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.InUse)
                    .IsRequired()
                    .HasColumnName("In_Use");

                entity.Property(e => e.MacAddress).HasColumnName("MAC_Address");

                entity.Property(e => e.ModelNumber).HasColumnName("Model_Number");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Category).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Location).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<VicidialApiLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vicidial_api_log");

                entity.Property(e => e.AgentUser)
                    .HasMaxLength(1)
                    .HasColumnName("agent_user");

                entity.Property(e => e.ApiDate).HasColumnName("api_date");

                entity.Property(e => e.ApiId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("api_id");

                entity.Property(e => e.ApiScript)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("api_script");

                entity.Property(e => e.ApiUrl).HasColumnName("api_url");

                entity.Property(e => e.Data)
                    .HasMaxLength(50)
                    .HasColumnName("data");

                entity.Property(e => e.Function)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("function");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("result");

                entity.Property(e => e.ResultReason)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("result_reason");

                entity.Property(e => e.RunTime).HasColumnName("run_time");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.User).HasColumnName("user");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");

                entity.Property(e => e.Webserver).HasColumnName("webserver");
            });

            modelBuilder.Entity<VicidialCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignId);

                entity.ToTable("vicidial_campaigns");

                entity.Property(e => e.CampaignId)
                    .HasMaxLength(50)
                    .HasColumnName("campaign_id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("active");

                entity.Property(e => e.AdaptiveDlDiffTarget)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adaptive_dl_diff_target");

                entity.Property(e => e.AdaptiveDroppedPercentage).HasColumnName("adaptive_dropped_percentage");

                entity.Property(e => e.AdaptiveIntensity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adaptive_intensity");

                entity.Property(e => e.AdaptiveLatestServerTime).HasColumnName("adaptive_latest_server_time");

                entity.Property(e => e.AdaptiveMaximumLevel).HasColumnName("adaptive_maximum_level");

                entity.Property(e => e.AgentAllowGroupAlias)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_allow_group_alias");

                entity.Property(e => e.AgentClipboardCopy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_clipboard_copy");

                entity.Property(e => e.AgentDialOwnerOnly)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_dial_owner_only");

                entity.Property(e => e.AgentDisplayDialableLeads)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_display_dialable_leads");

                entity.Property(e => e.AgentDisplayFields)
                    .HasMaxLength(1)
                    .HasColumnName("agent_display_fields");

                entity.Property(e => e.AgentExtendedAltDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_extended_alt_dial");

                entity.Property(e => e.AgentLeadSearch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_lead_search");

                entity.Property(e => e.AgentLeadSearchMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_lead_search_method");

                entity.Property(e => e.AgentPauseCodesActive)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_pause_codes_active");

                entity.Property(e => e.AgentScreenTimeDisplay)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_screen_time_display");

                entity.Property(e => e.AgentSearchMethod)
                    .HasMaxLength(1)
                    .HasColumnName("agent_search_method");

                entity.Property(e => e.AgentSelectTerritories)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_select_territories");

                entity.Property(e => e.AgentXferValidation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("agent_xfer_validation");

                entity.Property(e => e.AllcallsDelay)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allcalls_delay");

                entity.Property(e => e.AllowChats)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allow_chats");

                entity.Property(e => e.AllowClosers)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allow_closers");

                entity.Property(e => e.AllowEmails)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allow_emails");

                entity.Property(e => e.AllowRequiredFields)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allow_required_fields");

                entity.Property(e => e.AltNumberDialing)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("alt_number_dialing");

                entity.Property(e => e.AmMessageExten)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("am_message_exten");

                entity.Property(e => e.AmMessageWildcards)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("am_message_wildcards");

                entity.Property(e => e.AmdAgentRouteOptions)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amd_agent_route_options");

                entity.Property(e => e.AmdCallmenu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amd_callmenu");

                entity.Property(e => e.AmdInboundGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amd_inbound_group");

                entity.Property(e => e.AmdSendToVmx)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amd_send_to_vmx");

                entity.Property(e => e.AmdType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("amd_type");

                entity.Property(e => e.ApiManualDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("api_manual_dial");

                entity.Property(e => e.AutoActiveListNew)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_active_list_new");

                entity.Property(e => e.AutoAltDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_alt_dial");

                entity.Property(e => e.AutoAltDialStatuses)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_alt_dial_statuses");

                entity.Property(e => e.AutoDialLevel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_dial_level");

                entity.Property(e => e.AutoHopperLevel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_hopper_level");

                entity.Property(e => e.AutoHopperMulti)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_hopper_multi");

                entity.Property(e => e.AutoPausePrecall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_pause_precall");

                entity.Property(e => e.AutoPausePrecallCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_pause_precall_code");

                entity.Property(e => e.AutoResumePrecall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_resume_precall");

                entity.Property(e => e.AutoTrimHopper)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("auto_trim_hopper");

                entity.Property(e => e.AvailableOnlyRatioTally)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("available_only_ratio_tally");

                entity.Property(e => e.AvailableOnlyTallyThreshold)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("available_only_tally_threshold");

                entity.Property(e => e.AvailableOnlyTallyThresholdAgents)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("available_only_tally_threshold_agents");

                entity.Property(e => e.BlindMonitorFilename)
                    .HasMaxLength(1)
                    .HasColumnName("blind_monitor_filename");

                entity.Property(e => e.BlindMonitorMessage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("blind_monitor_message");

                entity.Property(e => e.BlindMonitorWarning)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("blind_monitor_warning");

                entity.Property(e => e.BrowserAlertSound)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("browser_alert_sound");

                entity.Property(e => e.BrowserAlertVolume).HasColumnName("browser_alert_volume");

                entity.Property(e => e.CallCountLimit).HasColumnName("call_count_limit");

                entity.Property(e => e.CallCountTarget).HasColumnName("call_count_target");

                entity.Property(e => e.CallLimit24hour)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_limit_24hour");

                entity.Property(e => e.CallLimit24hourMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_limit_24hour_method");

                entity.Property(e => e.CallLimit24hourOverride)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_limit_24hour_override");

                entity.Property(e => e.CallLimit24hourScope)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_limit_24hour_scope");

                entity.Property(e => e.CallQuotaLastRunDate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_quota_last_run_date");

                entity.Property(e => e.CallQuotaLeadRanking)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_quota_lead_ranking");

                entity.Property(e => e.CallQuotaProcessRunning)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_quota_process_running");

                entity.Property(e => e.CallRequeueButton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("call_requeue_button");

                entity.Property(e => e.CallbackActiveLimit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_active_limit");

                entity.Property(e => e.CallbackActiveLimitOverride)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_active_limit_override");

                entity.Property(e => e.CallbackDaysLimit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_days_limit");

                entity.Property(e => e.CallbackDisplayDays)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_display_days");

                entity.Property(e => e.CallbackDnc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_dnc");

                entity.Property(e => e.CallbackHoursBlock)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_hours_block");

                entity.Property(e => e.CallbackListCalltime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_list_calltime");

                entity.Property(e => e.CallbackUseronlyMoveMinutes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callback_useronly_move_minutes");

                entity.Property(e => e.CallsInqueueCountOne)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("calls_inqueue_count_one");

                entity.Property(e => e.CallsInqueueCountTwo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("calls_inqueue_count_two");

                entity.Property(e => e.CallsWaitingVlOne)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("calls_waiting_vl_one");

                entity.Property(e => e.CallsWaitingVlTwo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("calls_waiting_vl_two");

                entity.Property(e => e.CampaignAllowInbound)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_allow_inbound");

                entity.Property(e => e.CampaignCalldate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_calldate");

                entity.Property(e => e.CampaignChangedate).HasColumnName("campaign_changedate");

                entity.Property(e => e.CampaignCid).HasColumnName("campaign_cid");

                entity.Property(e => e.CampaignDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_description");

                entity.Property(e => e.CampaignLogindate).HasColumnName("campaign_logindate");

                entity.Property(e => e.CampaignName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_name");

                entity.Property(e => e.CampaignRecExten).HasColumnName("campaign_rec_exten");

                entity.Property(e => e.CampaignRecFilename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_rec_filename");

                entity.Property(e => e.CampaignRecording)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_recording");

                entity.Property(e => e.CampaignScript)
                    .HasMaxLength(1)
                    .HasColumnName("campaign_script");

                entity.Property(e => e.CampaignScriptTwo)
                    .HasMaxLength(1)
                    .HasColumnName("campaign_script_two");

                entity.Property(e => e.CampaignStatsRefresh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("campaign_stats_refresh");

                entity.Property(e => e.CampaignVdadExten).HasColumnName("campaign_vdad_exten");

                entity.Property(e => e.CidGroupId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cid_group_id");

                entity.Property(e => e.CidGroupIdTwo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cid_group_id_two");

                entity.Property(e => e.ClearForm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("clear_form");

                entity.Property(e => e.ClearScript)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("clear_script");

                entity.Property(e => e.CloserCampaigns)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("closer_campaigns");

                entity.Property(e => e.CommentsAllTabs)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("comments_all_tabs");

                entity.Property(e => e.CommentsCallbackScreen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("comments_callback_screen");

                entity.Property(e => e.CommentsDispoScreen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("comments_dispo_screen");

                entity.Property(e => e.ConcurrentTransfers)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("concurrent_transfers");

                entity.Property(e => e.CpdAmdAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cpd_amd_action");

                entity.Property(e => e.CpdUnknownAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cpd_unknown_action");

                entity.Property(e => e.CrmLoginAddress)
                    .HasMaxLength(1)
                    .HasColumnName("crm_login_address");

                entity.Property(e => e.CrmPopupLogin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("crm_popup_login");

                entity.Property(e => e.Custom3wayButtonTransfer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("custom_3way_button_transfer");

                entity.Property(e => e.Customer3wayHangupAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_3way_hangup_action");

                entity.Property(e => e.Customer3wayHangupLogging)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_3way_hangup_logging");

                entity.Property(e => e.Customer3wayHangupSeconds).HasColumnName("customer_3way_hangup_seconds");

                entity.Property(e => e.CustomerGoneSeconds).HasColumnName("customer_gone_seconds");

                entity.Property(e => e.DailyCallCountLimit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("daily_call_count_limit");

                entity.Property(e => e.DailyLimitManual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("daily_limit_manual");

                entity.Property(e => e.DeadMax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_max");

                entity.Property(e => e.DeadMaxDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_max_dispo");

                entity.Property(e => e.DeadToDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_to_dispo");

                entity.Property(e => e.DeadTriggerAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_trigger_action");

                entity.Property(e => e.DeadTriggerFilename)
                    .HasMaxLength(1)
                    .HasColumnName("dead_trigger_filename");

                entity.Property(e => e.DeadTriggerRepeat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_trigger_repeat");

                entity.Property(e => e.DeadTriggerSeconds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dead_trigger_seconds");

                entity.Property(e => e.DeadTriggerUrl)
                    .HasMaxLength(1)
                    .HasColumnName("dead_trigger_url");

                entity.Property(e => e.DefaultGroupAlias)
                    .HasMaxLength(1)
                    .HasColumnName("default_group_alias");

                entity.Property(e => e.DefaultXferGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("default_xfer_group");

                entity.Property(e => e.DialLevelThreshold)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dial_level_threshold");

                entity.Property(e => e.DialLevelThresholdAgents)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dial_level_threshold_agents");

                entity.Property(e => e.DialMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dial_method");

                entity.Property(e => e.DialPrefix).HasColumnName("dial_prefix");

                entity.Property(e => e.DialStatusA)
                    .HasMaxLength(1)
                    .HasColumnName("dial_status_a");

                entity.Property(e => e.DialStatusB)
                    .HasMaxLength(1)
                    .HasColumnName("dial_status_b");

                entity.Property(e => e.DialStatusC)
                    .HasMaxLength(1)
                    .HasColumnName("dial_status_c");

                entity.Property(e => e.DialStatusD)
                    .HasMaxLength(1)
                    .HasColumnName("dial_status_d");

                entity.Property(e => e.DialStatusE)
                    .HasMaxLength(1)
                    .HasColumnName("dial_status_e");

                entity.Property(e => e.DialStatuses)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("dial_statuses");

                entity.Property(e => e.DialTimeout).HasColumnName("dial_timeout");

                entity.Property(e => e.DialTimeoutLeadContainer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dial_timeout_lead_container");

                entity.Property(e => e.DisableAlterCustdata)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("disable_alter_custdata");

                entity.Property(e => e.DisableAlterCustphone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("disable_alter_custphone");

                entity.Property(e => e.DisableDispoScreen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("disable_dispo_screen");

                entity.Property(e => e.DisableDispoStatus)
                    .HasMaxLength(1)
                    .HasColumnName("disable_dispo_status");

                entity.Property(e => e.DisplayDialableCount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("display_dialable_count");

                entity.Property(e => e.DisplayLeadsCount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("display_leads_count");

                entity.Property(e => e.DisplayQueueCount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("display_queue_count");

                entity.Property(e => e.DispoCallUrl)
                    .HasMaxLength(1)
                    .HasColumnName("dispo_call_url");

                entity.Property(e => e.DispoMax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dispo_max");

                entity.Property(e => e.DispoMaxDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dispo_max_dispo");

                entity.Property(e => e.DlDiffTargetMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dl_diff_target_method");

                entity.Property(e => e.DropAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("drop_action");

                entity.Property(e => e.DropCallSeconds).HasColumnName("drop_call_seconds");

                entity.Property(e => e.DropInboundGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("drop_inbound_group");

                entity.Property(e => e.DropLockoutTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("drop_lockout_time");

                entity.Property(e => e.DropRateGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("drop_rate_group");

                entity.Property(e => e.EnableXferPresets)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("enable_xfer_presets");

                entity.Property(e => e.ExtensionAppendedCidname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("extension_appended_cidname");

                entity.Property(e => e.GetCallLaunch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("get_call_launch");

                entity.Property(e => e.GrabCallsInQueue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("grab_calls_in_queue");

                entity.Property(e => e.HangupXferRecordStart)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hangup_xfer_record_start");

                entity.Property(e => e.HideCallLogInfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hide_call_log_info");

                entity.Property(e => e.HideXferNumberToDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hide_xfer_number_to_dial");

                entity.Property(e => e.HopperDropRunTrigger)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hopper_drop_run_trigger");

                entity.Property(e => e.HopperLevel).HasColumnName("hopper_level");

                entity.Property(e => e.HopperVlcDupCheck)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hopper_vlc_dup_check");

                entity.Property(e => e.InGroupDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("in_group_dial");

                entity.Property(e => e.InGroupDialSelect)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("in_group_dial_select");

                entity.Property(e => e.InManDialNextReadySeconds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("in_man_dial_next_ready_seconds");

                entity.Property(e => e.InManDialNextReadySecondsOverride)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("in_man_dial_next_ready_seconds_override");

                entity.Property(e => e.InboundNoAgentsNoDialContainer)
                    .HasMaxLength(1)
                    .HasColumnName("inbound_no_agents_no_dial_container");

                entity.Property(e => e.InboundNoAgentsNoDialThreshold)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("inbound_no_agents_no_dial_threshold");

                entity.Property(e => e.InboundQueueNoDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("inbound_queue_no_dial");

                entity.Property(e => e.IvrParkCall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ivr_park_call");

                entity.Property(e => e.IvrParkCallAgi)
                    .HasMaxLength(1)
                    .HasColumnName("ivr_park_call_agi");

                entity.Property(e => e.LeadFilterId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lead_filter_id");

                entity.Property(e => e.LeadOrder)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lead_order");

                entity.Property(e => e.LeadOrderRandomize)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lead_order_randomize");

                entity.Property(e => e.LeadOrderSecondary)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lead_order_secondary");

                entity.Property(e => e.Leave3wayStartRecording)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("leave_3way_start_recording");

                entity.Property(e => e.Leave3wayStartRecordingException)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("leave_3way_start_recording_exception");

                entity.Property(e => e.LeaveVmMessageGroupId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("leave_vm_message_group_id");

                entity.Property(e => e.LeaveVmNoDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("leave_vm_no_dispo");

                entity.Property(e => e.ListOrderMix)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("list_order_mix");

                entity.Property(e => e.LocalCallTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("local_call_time");

                entity.Property(e => e.ManualAutoNext)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_auto_next");

                entity.Property(e => e.ManualAutoNextOptions)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_auto_next_options");

                entity.Property(e => e.ManualAutoShow)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_auto_show");

                entity.Property(e => e.ManualDialCallTimeCheck)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_call_time_check");

                entity.Property(e => e.ManualDialCid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_cid");

                entity.Property(e => e.ManualDialFilter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_filter");

                entity.Property(e => e.ManualDialHopperCheck)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_hopper_check");

                entity.Property(e => e.ManualDialLeadId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_lead_id");

                entity.Property(e => e.ManualDialListId).HasColumnName("manual_dial_list_id");

                entity.Property(e => e.ManualDialOverride)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_override");

                entity.Property(e => e.ManualDialOverrideField)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_override_field");

                entity.Property(e => e.ManualDialPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("manual_dial_prefix");

                entity.Property(e => e.ManualDialSearchCheckbox)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_search_checkbox");

                entity.Property(e => e.ManualDialSearchFilter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_search_filter");

                entity.Property(e => e.ManualDialTimeout)
                    .HasMaxLength(1)
                    .HasColumnName("manual_dial_timeout");

                entity.Property(e => e.ManualDialValidation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_dial_validation");

                entity.Property(e => e.ManualPreviewDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manual_preview_dial");

                entity.Property(e => e.MaxInboundCalls)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("max_inbound_calls");

                entity.Property(e => e.MaxInboundCallsOutcome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("max_inbound_calls_outcome");

                entity.Property(e => e.MuteRecordings)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mute_recordings");

                entity.Property(e => e.MyCallbackOption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("my_callback_option");

                entity.Property(e => e.NaCallUrl)
                    .HasMaxLength(1)
                    .HasColumnName("na_call_url");

                entity.Property(e => e.NextAgentCall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("next_agent_call");

                entity.Property(e => e.NextDialMyCallbacks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("next_dial_my_callbacks");

                entity.Property(e => e.NoHopperDialing)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("no_hopper_dialing");

                entity.Property(e => e.NoHopperLeadsLogins)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("no_hopper_leads_logins");

                entity.Property(e => e.OfcomUkDropCalc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ofcom_uk_drop_calc");

                entity.Property(e => e.OmitPhoneCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("omit_phone_code");

                entity.Property(e => e.OpensipsCidName)
                    .HasMaxLength(1)
                    .HasColumnName("opensips_cid_name");

                entity.Property(e => e.OwnerPopulate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("owner_populate");

                entity.Property(e => e.ParkExt)
                    .HasMaxLength(1)
                    .HasColumnName("park_ext");

                entity.Property(e => e.ParkFileName)
                    .HasMaxLength(1)
                    .HasColumnName("park_file_name");

                entity.Property(e => e.PauseAfterEachCall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pause_after_each_call");

                entity.Property(e => e.PauseAfterNextCall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pause_after_next_call");

                entity.Property(e => e.PauseMax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pause_max");

                entity.Property(e => e.PauseMaxDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pause_max_dispo");

                entity.Property(e => e.PauseMaxExceptions)
                    .HasMaxLength(1)
                    .HasColumnName("pause_max_exceptions");

                entity.Property(e => e.PerCallNotes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("per_call_notes");

                entity.Property(e => e.PllbGrouping)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pllb_grouping");

                entity.Property(e => e.PllbGroupingLimit).HasColumnName("pllb_grouping_limit");

                entity.Property(e => e.PostPhoneTimeDiffAlert)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("post_phone_time_diff_alert");

                entity.Property(e => e.PrepopulateTransferPreset)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prepopulate_transfer_preset");

                entity.Property(e => e.QcCommentHistory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_comment_history");

                entity.Property(e => e.QcEnabled)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_enabled");

                entity.Property(e => e.QcGetRecordLaunch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_get_record_launch");

                entity.Property(e => e.QcLists)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_lists");

                entity.Property(e => e.QcScorecardId)
                    .HasMaxLength(1)
                    .HasColumnName("qc_scorecard_id");

                entity.Property(e => e.QcScript)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_script");

                entity.Property(e => e.QcShiftId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_shift_id");

                entity.Property(e => e.QcShowRecording)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_show_recording");

                entity.Property(e => e.QcStatuses)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_statuses");

                entity.Property(e => e.QcStatusesId)
                    .HasMaxLength(1)
                    .HasColumnName("qc_statuses_id");

                entity.Property(e => e.QcWebFormAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("qc_web_form_address");

                entity.Property(e => e.QueuePriority).HasColumnName("queue_priority");

                entity.Property(e => e.QueuemetricsCallstatusOverride)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("queuemetrics_callstatus_override");

                entity.Property(e => e.QueuemetricsPhoneEnvironment)
                    .HasMaxLength(1)
                    .HasColumnName("queuemetrics_phone_environment");

                entity.Property(e => e.QuickTransferButton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("quick_transfer_button");

                entity.Property(e => e.ReadyMaxLogout)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ready_max_logout");

                entity.Property(e => e.RealtimeAgentTimeStats)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("realtime_agent_time_stats");

                entity.Property(e => e.RoutingInitiatedRecordings)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("routing_initiated_recordings");

                entity.Property(e => e.SafeHarborAudio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("safe_harbor_audio");

                entity.Property(e => e.SafeHarborAudioField)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("safe_harbor_audio_field");

                entity.Property(e => e.SafeHarborExten).HasColumnName("safe_harbor_exten");

                entity.Property(e => e.SafeHarborMenuId)
                    .HasMaxLength(1)
                    .HasColumnName("safe_harbor_menu_id");

                entity.Property(e => e.ScheduledCallbacks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks");

                entity.Property(e => e.ScheduledCallbacksAlert)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_alert");

                entity.Property(e => e.ScheduledCallbacksAutoReschedule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_auto_reschedule");

                entity.Property(e => e.ScheduledCallbacksCount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_count");

                entity.Property(e => e.ScheduledCallbacksEmailAlert)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_email_alert");

                entity.Property(e => e.ScheduledCallbacksForceDial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_force_dial");

                entity.Property(e => e.ScheduledCallbacksTimezonesContainer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled_callbacks_timezones_container");

                entity.Property(e => e.ScreenLabels)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("screen_labels");

                entity.Property(e => e.ScriptTopDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("script_top_dispo");

                entity.Property(e => e.SharedDialRank).HasColumnName("shared_dial_rank");

                entity.Property(e => e.ShowPreviousCallback)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("show_previous_callback");

                entity.Property(e => e.SipEventLogging)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sip_event_logging");

                entity.Property(e => e.StartCallUrl)
                    .HasMaxLength(1)
                    .HasColumnName("start_call_url");

                entity.Property(e => e.StatusDisplayFields)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status_display_fields");

                entity.Property(e => e.StatusDisplayIngroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status_display_ingroup");

                entity.Property(e => e.SurveyCampRecordDir)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_camp_record_dir");

                entity.Property(e => e.SurveyDtmfDigits).HasColumnName("survey_dtmf_digits");

                entity.Property(e => e.SurveyFirstAudioFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_first_audio_file");

                entity.Property(e => e.SurveyFourthAudioFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_fourth_audio_file");

                entity.Property(e => e.SurveyFourthDigit)
                    .HasMaxLength(1)
                    .HasColumnName("survey_fourth_digit");

                entity.Property(e => e.SurveyFourthExten).HasColumnName("survey_fourth_exten");

                entity.Property(e => e.SurveyFourthStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_fourth_status");

                entity.Property(e => e.SurveyMenuId)
                    .HasMaxLength(1)
                    .HasColumnName("survey_menu_id");

                entity.Property(e => e.SurveyMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_method");

                entity.Property(e => e.SurveyNiAudioFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_ni_audio_file");

                entity.Property(e => e.SurveyNiDigit).HasColumnName("survey_ni_digit");

                entity.Property(e => e.SurveyNiStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_ni_status");

                entity.Property(e => e.SurveyNoResponseAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_no_response_action");

                entity.Property(e => e.SurveyOptInAudioFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_opt_in_audio_file");

                entity.Property(e => e.SurveyRecording)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_recording");

                entity.Property(e => e.SurveyResponseDigitMap)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("survey_response_digit_map");

                entity.Property(e => e.SurveyThirdAudioFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_third_audio_file");

                entity.Property(e => e.SurveyThirdDigit)
                    .HasMaxLength(1)
                    .HasColumnName("survey_third_digit");

                entity.Property(e => e.SurveyThirdExten).HasColumnName("survey_third_exten");

                entity.Property(e => e.SurveyThirdStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("survey_third_status");

                entity.Property(e => e.SurveyWaitSec).HasColumnName("survey_wait_sec");

                entity.Property(e => e.SurveyXferExten).HasColumnName("survey_xfer_exten");

                entity.Property(e => e.ThreeWayCallCid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("three_way_call_cid");

                entity.Property(e => e.ThreeWayDialPrefix)
                    .HasMaxLength(1)
                    .HasColumnName("three_way_dial_prefix");

                entity.Property(e => e.ThreeWayRecordStop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("three_way_record_stop");

                entity.Property(e => e.ThreeWayRecordStopException)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("three_way_record_stop_exception");

                entity.Property(e => e.ThreeWayVolumeButtons)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("three_way_volume_buttons");

                entity.Property(e => e.TimerAction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("timer_action");

                entity.Property(e => e.TimerActionDestination)
                    .HasMaxLength(1)
                    .HasColumnName("timer_action_destination");

                entity.Property(e => e.TimerActionMessage)
                    .HasMaxLength(1)
                    .HasColumnName("timer_action_message");

                entity.Property(e => e.TimerActionSeconds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("timer_action_seconds");

                entity.Property(e => e.TimerAltSeconds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("timer_alt_seconds");

                entity.Property(e => e.TransferButtonLaunch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("transfer_button_launch");

                entity.Property(e => e.TransferNoDispo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("transfer_no_dispo");

                entity.Property(e => e.UseAutoHopper)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("use_auto_hopper");

                entity.Property(e => e.UseCampaignDnc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("use_campaign_dnc");

                entity.Property(e => e.UseCustomCid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("use_custom_cid");

                entity.Property(e => e.UseInternalDnc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("use_internal_dnc");

                entity.Property(e => e.UseOtherCampaignDnc)
                    .HasMaxLength(1)
                    .HasColumnName("use_other_campaign_dnc");

                entity.Property(e => e.UserGroup)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_group");

                entity.Property(e => e.ViewCallsInQueue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("view_calls_in_queue");

                entity.Property(e => e.ViewCallsInQueueLaunch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("view_calls_in_queue_launch");

                entity.Property(e => e.VmmDailyLimit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vmm_daily_limit");

                entity.Property(e => e.VoicemailExt)
                    .HasMaxLength(1)
                    .HasColumnName("voicemail_ext");

                entity.Property(e => e.VtigerCreateCallRecord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_create_call_record");

                entity.Property(e => e.VtigerCreateLeadRecord)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_create_lead_record");

                entity.Property(e => e.VtigerScreenLogin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_screen_login");

                entity.Property(e => e.VtigerSearchCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_search_category");

                entity.Property(e => e.VtigerSearchDead)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_search_dead");

                entity.Property(e => e.VtigerStatusCall)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("vtiger_status_call");

                entity.Property(e => e.WaitforsilenceOptions)
                    .HasMaxLength(1)
                    .HasColumnName("waitforsilence_options");

                entity.Property(e => e.WebFormAddress)
                    .HasMaxLength(1)
                    .HasColumnName("web_form_address");

                entity.Property(e => e.WebFormAddressThree)
                    .HasMaxLength(1)
                    .HasColumnName("web_form_address_three");

                entity.Property(e => e.WebFormAddressTwo)
                    .HasMaxLength(1)
                    .HasColumnName("web_form_address_two");

                entity.Property(e => e.WebFormTarget)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("web_form_target");

                entity.Property(e => e.WrapupAfterHotkey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("wrapup_after_hotkey");

                entity.Property(e => e.WrapupBypass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("wrapup_bypass");

                entity.Property(e => e.WrapupMessage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("wrapup_message");

                entity.Property(e => e.WrapupSeconds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("wrapup_seconds");

                entity.Property(e => e.XferGroups)
                    .HasMaxLength(50)
                    .HasColumnName("xfer_groups");

                entity.Property(e => e.XferconfADtmf)
                    .HasMaxLength(1)
                    .HasColumnName("xferconf_a_dtmf");

                entity.Property(e => e.XferconfANumber)
                    .HasMaxLength(50)
                    .HasColumnName("xferconf_a_number");

                entity.Property(e => e.XferconfBDtmf)
                    .HasMaxLength(1)
                    .HasColumnName("xferconf_b_dtmf");

                entity.Property(e => e.XferconfBNumber)
                    .HasMaxLength(50)
                    .HasColumnName("xferconf_b_number");

                entity.Property(e => e.XferconfCNumber)
                    .HasMaxLength(50)
                    .HasColumnName("xferconf_c_number");

                entity.Property(e => e.XferconfDNumber)
                    .HasMaxLength(50)
                    .HasColumnName("xferconf_d_number");

                entity.Property(e => e.XferconfENumber)
                    .HasMaxLength(50)
                    .HasColumnName("xferconf_e_number");
            });

            modelBuilder.Entity<VicidialCarrierLog>(entity =>
            {
                entity.HasKey(e => e.Uniqueid);

                entity.ToTable("vicidial_carrier_log");

                entity.Property(e => e.Uniqueid).HasColumnName("uniqueid");

                entity.Property(e => e.AnsweredTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("answered_time");

                entity.Property(e => e.CallDate).HasColumnName("call_date");

                entity.Property(e => e.CallerCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("caller_code");

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("channel");

                entity.Property(e => e.DialTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dial_time");

                entity.Property(e => e.Dialstatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dialstatus");

                entity.Property(e => e.HangupCause)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("hangup_cause");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.ServerIp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("server_ip");

                entity.Property(e => e.SipHangupCause)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sip_hangup_cause");

                entity.Property(e => e.SipHangupReason)
                    .HasMaxLength(50)
                    .HasColumnName("sip_hangup_reason");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
