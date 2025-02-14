from enum import Enum
from typing import TypeVar, Dict, Union
from sqlalchemy import asc, desc, Column
from sqlalchemy.sql.expression import Select
from sqlalchemy.orm import DeclarativeBase

M = TypeVar('M', bound=DeclarativeBase)

class SortOrder(Enum):
    NONE = 0
    ASC = 1
    DESC = 2

def sort_query(
    query: Select[tuple[M]],
    sort_order: Dict[Union[str, Column], SortOrder | None]
) -> Select[tuple[M]]:
    sorted_query = query

    for key, order in sort_order.items():
        if order is None or order is SortOrder.NONE:
            continue

        if sort_order is SortOrder.ASC:
            sorted_query = sorted_query.order_by(asc(key))
        else:
            sorted_query = sorted_query.order_by(desc(key))

    return sorted_query
