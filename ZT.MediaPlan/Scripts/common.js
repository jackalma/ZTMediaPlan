function remCommas(nStr) {
    while (nStr.indexOf(",") != -1) {
        nStr = nStr.replace(',', '');
    }
    return nStr;
}