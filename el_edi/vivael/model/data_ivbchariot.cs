using System;

namespace vivael
{
	public class data_ivbchariot : DataSource
	{
		public data_ivbchariot() { Table_name = i.name = "ivbchariot"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private DateTime? _Daterap; public DateTime? Daterap { get { return _Daterap; } set { Set(ref _Daterap, value, "Daterap"); } }
		private string _Hrsrap; public string Hrsrap { get { return _Hrsrap; } set { Set(ref _Hrsrap, value, "Hrsrap"); } }
		private int? _Hrschariot; public int? Hrschariot { get { return _Hrschariot; } set { Set(ref _Hrschariot, value, "Hrschariot"); } }
		private string _Xchariot; public string Xchariot { get { return _Xchariot; } set { Set(ref _Xchariot, value, "Xchariot"); } }
		private string _Operateur; public string Operateur { get { return _Operateur; } set { Set(ref _Operateur, value, "Operateur"); } }
		private byte? _Ajouteau; public byte? Ajouteau { get { return _Ajouteau; } set { Set(ref _Ajouteau, value, "Ajouteau"); } }
		private byte? _Iv1but; public byte? Iv1but { get { return _Iv1but; } set { Set(ref _Iv1but, value, "Iv1but"); } }
		private byte? _Iv1bou; public byte? Iv1bou { get { return _Iv1bou; } set { Set(ref _Iv1bou, value, "Iv1bou"); } }
		private byte? _Iv1cou; public byte? Iv1cou { get { return _Iv1cou; } set { Set(ref _Iv1cou, value, "Iv1cou"); } }
		private byte? _Iv1cab; public byte? Iv1cab { get { return _Iv1cab; } set { Set(ref _Iv1cab, value, "Iv1cab"); } }
		private byte? _Iv2toit; public byte? Iv2toit { get { return _Iv2toit; } set { Set(ref _Iv2toit, value, "Iv2toit"); } }
		private byte? _Iv3gpneuav; public byte? Iv3gpneuav { get { return _Iv3gpneuav; } set { Set(ref _Iv3gpneuav, value, "Iv3gpneuav"); } }
		private byte? _Iv4gcyli; public byte? Iv4gcyli { get { return _Iv4gcyli; } set { Set(ref _Iv4gcyli, value, "Iv4gcyli"); } }
		private byte? _Iv5gtab; public byte? Iv5gtab { get { return _Iv5gtab; } set { Set(ref _Iv5gtab, value, "Iv5gtab"); } }
		private byte? _Iv6ggoup; public byte? Iv6ggoup { get { return _Iv6ggoup; } set { Set(ref _Iv6ggoup, value, "Iv6ggoup"); } }
		private byte? _Iv7gfou; public byte? Iv7gfou { get { return _Iv7gfou; } set { Set(ref _Iv7gfou, value, "Iv7gfou"); } }
		private byte? _Iv8mat; public byte? Iv8mat { get { return _Iv8mat; } set { Set(ref _Iv8mat, value, "Iv8mat"); } }
		private byte? _Iv9dcyle; public byte? Iv9dcyle { get { return _Iv9dcyle; } set { Set(ref _Iv9dcyle, value, "Iv9dcyle"); } }
		private byte? _Iv10dfou; public byte? Iv10dfou { get { return _Iv10dfou; } set { Set(ref _Iv10dfou, value, "Iv10dfou"); } }
		private byte? _Iv11dgou; public byte? Iv11dgou { get { return _Iv11dgou; } set { Set(ref _Iv11dgou, value, "Iv11dgou"); } }
		private byte? _Iv12dtab; public byte? Iv12dtab { get { return _Iv12dtab; } set { Set(ref _Iv12dtab, value, "Iv12dtab"); } }
		private byte? _Iv13dcyli; public byte? Iv13dcyli { get { return _Iv13dcyli; } set { Set(ref _Iv13dcyli, value, "Iv13dcyli"); } }
		private byte? _Iv14dpneuav; public byte? Iv14dpneuav { get { return _Iv14dpneuav; } set { Set(ref _Iv14dpneuav, value, "Iv14dpneuav"); } }
		private byte? _Iv15huihy; public byte? Iv15huihy { get { return _Iv15huihy; } set { Set(ref _Iv15huihy, value, "Iv15huihy"); } }
		private byte? _Iv16rcbat; public byte? Iv16rcbat { get { return _Iv16rcbat; } set { Set(ref _Iv16rcbat, value, "Iv16rcbat"); } }
		private byte? _Iv17siege; public byte? Iv17siege { get { return _Iv17siege; } set { Set(ref _Iv17siege, value, "Iv17siege"); } }
		private byte? _Iv18toit; public byte? Iv18toit { get { return _Iv18toit; } set { Set(ref _Iv18toit, value, "Iv18toit"); } }
		private byte? _Iv19dpneuar; public byte? Iv19dpneuar { get { return _Iv19dpneuar; } set { Set(ref _Iv19dpneuar, value, "Iv19dpneuar"); } }
		private byte? _Iv20gpneuar; public byte? Iv20gpneuar { get { return _Iv20gpneuar; } set { Set(ref _Iv20gpneuar, value, "Iv20gpneuar"); } }
		private byte? _Iva; public byte? Iva { get { return _Iva; } set { Set(ref _Iva, value, "Iva"); } }
		private byte? _Ivb; public byte? Ivb { get { return _Ivb; } set { Set(ref _Ivb, value, "Ivb"); } }
		private byte? _Ivc; public byte? Ivc { get { return _Ivc; } set { Set(ref _Ivc, value, "Ivc"); } }
		private byte? _Ivd; public byte? Ivd { get { return _Ivd; } set { Set(ref _Ivd, value, "Ivd"); } }
		private byte? _Ivecond; public byte? Ivecond { get { return _Ivecond; } set { Set(ref _Ivecond, value, "Ivecond"); } }
		private byte? _Iveacc; public byte? Iveacc { get { return _Iveacc; } set { Set(ref _Iveacc, value, "Iveacc"); } }
		private byte? _Ivedir; public byte? Ivedir { get { return _Ivedir; } set { Set(ref _Ivedir, value, "Ivedir"); } }
		private byte? _Ivefrein; public byte? Ivefrein { get { return _Ivefrein; } set { Set(ref _Ivefrein, value, "Ivefrein"); } }
		private byte? _Ivfcond; public byte? Ivfcond { get { return _Ivfcond; } set { Set(ref _Ivfcond, value, "Ivfcond"); } }
		private byte? _Ivfacc; public byte? Ivfacc { get { return _Ivfacc; } set { Set(ref _Ivfacc, value, "Ivfacc"); } }
		private byte? _Ivfdir; public byte? Ivfdir { get { return _Ivfdir; } set { Set(ref _Ivfdir, value, "Ivfdir"); } }
		private byte? _Ivffrein; public byte? Ivffrein { get { return _Ivffrein; } set { Set(ref _Ivffrein, value, "Ivffrein"); } }
		private byte? _Ivfavert; public byte? Ivfavert { get { return _Ivfavert; } set { Set(ref _Ivfavert, value, "Ivfavert"); } }
		private byte? _Ivglum; public byte? Ivglum { get { return _Ivglum; } set { Set(ref _Ivglum, value, "Ivglum"); } }
		private byte? _Ivhklax; public byte? Ivhklax { get { return _Ivhklax; } set { Set(ref _Ivhklax, value, "Ivhklax"); } }
		private byte? _Ivijauge; public byte? Ivijauge { get { return _Ivijauge; } set { Set(ref _Ivijauge, value, "Ivijauge"); } }
		private byte? _Ivjflaq; public byte? Ivjflaq { get { return _Ivjflaq; } set { Set(ref _Ivjflaq, value, "Ivjflaq"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private int? _Idequip; public int? Idequip { get { return _Idequip; } set { Set(ref _Idequip, value, "Idequip"); } }

	}
}