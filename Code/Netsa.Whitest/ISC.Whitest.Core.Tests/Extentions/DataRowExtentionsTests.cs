using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ISC.Whitest.Core.Extentions;
using Xunit;

namespace ISC.Whitest.Core.Tests.Extentions
{
    public class DataRowExtentionsTests
    {
        [Fact]
        public void ValueOfCell_should_read_value_of_cell_and_convert_to_desirable_type()
        {
            //Arrange
            const string idColumn = "Id";
            const string nameColumn = "Name";
            const long valueOfId = 1;

            var table = new DataTable();
            table.Columns.Add(idColumn);
            table.Columns.Add(nameColumn);

            var row = table.NewRow();
            row[idColumn] = valueOfId;
            row[nameColumn] = "Jack";

            //Act
            var value = row.ValueOfCell<long>(idColumn);

            //Assert
            value.Should().Be(valueOfId);
        }
    }
}
