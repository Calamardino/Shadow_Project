public static class BattleData
{
	public enum BattleOutcome {
		WON,
		LOST,

		NO_BATTLE
	}

	public static int battlesWon = 0;
	public static int battlesLost = 0;

	public static BattleOutcome lastBattleOutcome = BattleOutcome.NO_BATTLE;
}