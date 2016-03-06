public function Horribles()
{
    QualitySettings.currentLevel = QualityLevel.Fastest;
}

public function Bajos()
{
    QualitySettings.currentLevel = QualityLevel.Fast;
}

public function Medios()
{
    QualitySettings.currentLevel = QualityLevel.Simple;
}

public function Normales()
{
    QualitySettings.currentLevel = QualityLevel.Good;
}

public function Buenos()
{
    QualitySettings.currentLevel = QualityLevel.Beautiful;
}

public function Excelentes()
{
    QualitySettings.currentLevel = QualityLevel.Fantastic;
}