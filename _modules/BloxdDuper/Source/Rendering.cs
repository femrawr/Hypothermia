using ClickableTransparentOverlay;
using ImGuiNET;

using System.Numerics;

namespace BloxdDuper.Source
{
	public class Rendering : Overlay
	{
		protected override void Render()
		{
			ImGui.SetNextWindowSize(new Vector2(400, 300));
			ImGui.Begin("Hypothermia", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);

			if (ImGui.BeginTabBar("Tabs"))
			{
				if (ImGui.BeginTabItem("Main"))
				{
					RenderMain();
					ImGui.EndTabItem();
				}

				if (ImGui.BeginTabItem("Dupe"))
				{
					RenderDupe();
					ImGui.EndTabItem();
				}

				ImGui.EndTabBar();
			}

			ImGui.End();
		}

		private void RenderMain()
		{
			ImGui.Checkbox("Kill Aura", ref _aura);
			ImGui.SliderInt("Range", ref _range, 1, 10);

			ImGui.Spacing();
			ImGui.Separator();

			ImGui.Checkbox("Flight", ref _fly);
			ImGui.SliderInt("Speed", ref _speed, 10, 100);

			ImGui.Spacing();
			ImGui.Separator();

			ImGui.Checkbox("Scaffold", ref _block);
			ImGui.Checkbox("ESP", ref _esp);
			ImGui.Checkbox("Aimbot", ref _aim);
		}

		private void RenderDupe()
		{
			if (ImGui.Button(_dupeEnabled ? "Stop Dupe" : "Start Dupe", new Vector2(130, 25)))
			{
				_dupeEnabled = !_dupeEnabled;
			}

			ImGui.Spacing();
			ImGui.Separator();

			ImGui.Button("Drop Item", new Vector2(130, 25));
			ImGui.SameLine();
			ImGui.Button("Drop All Items", new Vector2(130, 25));
		}

		private bool _aura = false;
		private int _range = 1;

		private bool _fly = false;
		private int _speed = 10;

		private bool _block = false;
		private bool _esp = false;
		private bool _aim = false;

		private bool _dupeEnabled = false;
	}
}
