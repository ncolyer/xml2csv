<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="text" encoding="UTF-8"/>
  
  <xsl:template match="/ReportOutput/ReportBody/ReportSection/String">
    <xsl:text>,</xsl:text>
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="/ReportOutput/ReportBody/ReportSection/ReportSection/ReportSection/ReportSection/ReportSection/String">
    <xsl:text>,</xsl:text>
    <xsl:value-of select="."/>
    <xsl:text>&#10;</xsl:text>
  </xsl:template>
 
</xsl:stylesheet>
